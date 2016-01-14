using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiProjekt.Algorithms
{
    public class RSA
    {
        private string _publicKey;
        private string _privateKey;
        public string PublicKey
        {
            get
            {
                return FileManager.ReadFromXMLFile("PublicKey");
            }
        }

        public string PrivateKey
        {
            get
            {
                return FileManager.ReadFromXMLFile("PrivateKey");
            }
        }

        public RSA()
        {
        }

        public byte[] Encrypt(string dataToDycript)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PublicKey);
            return rsa.Encrypt(Convert.FromBase64String(dataToDycript), true);
        }

        public string Decrypt(byte[] encryptedData)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PrivateKey);
            return Convert.ToBase64String(rsa.Decrypt(encryptedData, true));
        }

        public void AssignNewRSAKey()
        {
            RSACryptoServiceProvider rsa = null;
            const int PROVIDER_RSA_FULL = 1;
            const string CONTAINER_NAME = "KeyContainer";
            CspParameters cspParams;
            cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            rsa = new RSACryptoServiceProvider(1024, cspParams);
            FileManager.WriteToXmlFile("PublicKey", rsa.ToXmlString(false));
            FileManager.WriteToXmlFile("PrivateKey", rsa.ToXmlString(true));
            FileManager.ReplaceSubstringInFile("<", "&lt;");
            FileManager.ReplaceSubstringInFile(">", "&gt;");
        }
    }
}
