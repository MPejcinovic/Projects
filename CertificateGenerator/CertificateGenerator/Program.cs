using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            AsymmetricCipherKeyPair keyPair;
            var x509 = GenerateCertificate("Subject", out keyPair);

            string FilePath = "cert.pfx";
            string Alias = "foo";
            string Pwd = "bar";


            SaveToFile(x509, keyPair, FilePath, Alias, Pwd);

            var x5092 = new System.Security.Cryptography.X509Certificates.X509Certificate2(FilePath, Pwd);

            Console.WriteLine(String.Format("SubjectName: {0}", x5092.SubjectName));
            Console.WriteLine(String.Format("ThumbPrint: {1}", x5092.Thumbprint));
            Console.WriteLine(String.Format("SignatureAlgorithm: {2}", x5092.PrivateKey.SignatureAlgorithm));
            Console.ReadLine();
        }

        private static void SaveToFile(X509Certificate x509, AsymmetricCipherKeyPair keyPair, string filePath, string alias, string pwd)
        {
            var newStore = new Pkcs12Store();
            var certEntry = new X509CertificateEntry(x509);

            newStore.SetCertificateEntry(alias, certEntry);

            newStore.SetKeyEntry(alias, new AsymmetricKeyEntry(keyPair.Private), new[] { certEntry });

            using (var certFile = File.Create(filePath))
            {
                newStore.Save(certFile, pwd.ToCharArray(), new Org.BouncyCastle.Security.SecureRandom(new CryptoApiRandomGenerator()));
            }
        }

        public static X509Certificate GenerateCertificate(string subjectName, out AsymmetricCipherKeyPair keyP)
        {
            var kpGen = new RsaKeyPairGenerator();

            kpGen.Init(new KeyGenerationParameters(new Org.BouncyCastle.Security.SecureRandom(new CryptoApiRandomGenerator()), 1024));
            keyP = kpGen.GenerateKeyPair();

            var gen = new X509V3CertificateGenerator();

            var certName = new X509Name("CN=" + subjectName);
            var serialNo = BigInteger.ProbablePrime(120, new Random());

            gen.SetSerialNumber(serialNo);
            gen.SetSubjectDN(certName);
            gen.SetIssuerDN(certName);
            gen.SetNotAfter(DateTime.Now.AddYears(100));
            gen.SetNotBefore(DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)));

            gen.SetSignatureAlgorithm("SHA1withRSA");
            gen.SetPublicKey(keyP.Public);

            gen.AddExtension(X509Extensions.AuthorityKeyIdentifier.Id, false, new AuthorityKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keyP.Public), new GeneralNames(new GeneralName(certName)), serialNo));

            gen.AddExtension(X509Extensions.ExtendedKeyUsage.Id, false, new ExtendedKeyUsage(new[] { KeyPurposeID.IdKPServerAuth }));

            var newCert = gen.Generate(keyP.Private);
            return newCert;
        }
    }
}
