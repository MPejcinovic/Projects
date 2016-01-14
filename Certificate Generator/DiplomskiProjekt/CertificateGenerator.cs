using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiProjekt
{
    class CertificateGenerator
    {
        private BigInteger _serialNumber;
        private string _subjectName;
        private SecureRandom _random;
        private string _signatureAlgorithm;
        private DateTime _validFrom;
        private DateTime _validTill;

        public DateTime ValidFrom
        {
            get
            {
                return _validFrom;
            }
            set
            {
                _validFrom = value;
            }
        }

        public DateTime ValidTill
        {
            get
            {
                return _validTill;
            }
            set
            {
                _validTill = value;
            }
        }

        public string SignatureAlgorithm
        {
            get
            {
                return _signatureAlgorithm;
            }
            set
            {
                _signatureAlgorithm = value;
            }
        }

        public BigInteger SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
            }
        }

        public string SubjectName
        {
            get
            {
                return _subjectName;
            }
            set
            {
                _subjectName = value;
            }
        }

        public SecureRandom Random
        {
            get
            {
                return _random;
            }
            set
            {
                _random = value;
            }
        }

        public CertificateGenerator(string subjectName, string signatureAlgorithm, DateTime validFrom, DateTime validTill)
        {
            SubjectName = subjectName;
            SignatureAlgorithm = signatureAlgorithm;
            ValidFrom = validFrom;
            ValidTill = validTill;
            ProvideEssentialParameters();
        }

        private void ProvideEssentialParameters()
        {
            var randomGenerator = new CryptoApiRandomGenerator();
            Random = new SecureRandom(randomGenerator);

            SerialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), Random);
        }

        public X509Certificate2 CreateCertificate()
        {
            X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();

            var subjectDN = new X509Name(String.Format("CN={0}", SubjectName));
            var issuerDN = subjectDN;

            AsymmetricKeyParameter privateKey;
            AsymmetricKeyParameter publicKey;
            RsaKeysGenerator(out privateKey, out publicKey);

            var authorityKeyIdentifier = new AuthorityKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey), new GeneralNames(new GeneralName(issuerDN)), SerialNumber);
            var subjectKeyIdentifier = new SubjectKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey));

            certificateGenerator.SetIssuerDN(issuerDN);
            certificateGenerator.SetSubjectDN(subjectDN);

            certificateGenerator.SetSerialNumber(SerialNumber);

            certificateGenerator.SetNotBefore(ValidFrom);
            certificateGenerator.SetNotAfter(ValidTill);

            certificateGenerator.SetSignatureAlgorithm(SignatureAlgorithm);

            certificateGenerator.SetPublicKey(publicKey);

            certificateGenerator.AddExtension(X509Extensions.AuthorityKeyIdentifier.Id, false, authorityKeyIdentifier);
            certificateGenerator.AddExtension(X509Extensions.SubjectKeyIdentifier.Id, false, subjectKeyIdentifier);
            certificateGenerator.AddExtension(X509Extensions.BasicConstraints.Id, true, new BasicConstraints(false));

            var certificate = certificateGenerator.Generate(privateKey, Random);

            PrivateKeyInfo info = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);

            var x509 = new X509Certificate2(certificate.GetEncoded());

            var seq = (Asn1Sequence)Asn1Object.FromByteArray(info.PrivateKey.GetDerEncoded());
            if (seq.Count != 9)
                throw new PemException("malformed sequence in RSA private key");

            var rsa = new RsaPrivateKeyStructure(seq);
            RsaPrivateCrtKeyParameters rsaparams = new RsaPrivateCrtKeyParameters(
                rsa.Modulus, rsa.PublicExponent, rsa.PrivateExponent, rsa.Prime1, rsa.Prime2, rsa.Exponent1, rsa.Exponent2, rsa.Coefficient);

            x509.PrivateKey = DotNetUtilities.ToRSA(rsaparams);
            return x509;
        }

        private void RsaKeysGenerator(out AsymmetricKeyParameter privateKey, out AsymmetricKeyParameter publicKey)
        {
            int keyLength = 2048;
            var parameters = new KeyGenerationParameters(Random, keyLength);

            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(parameters);
            var subjectKeyPair = keyPairGenerator.GenerateKeyPair();

            publicKey = subjectKeyPair.Public;
            privateKey = subjectKeyPair.Private;
        }

        public bool StoreCertificate(X509Certificate2 certificate, StoreName certificateStore, StoreLocation storeLocation)
        {
            bool flag = false;

            try
            {
                X509Store store = new X509Store(certificateStore, storeLocation);
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);

                store.Close();
                flag = true;
            }
            catch
            {

            }

            return flag;
        }

        public static List<string> ImportCertificate()
        {
            List<string> certificateList = new List<string>();

            X509Store store = new X509Store("My");

            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 certificate in store.Certificates)
            {
                certificateList.Add(String.Format("Subject: {0}; Serial number: {1};", certificate.Subject, certificate.SerialNumber));
            }
            return certificateList;
        }
    }
}