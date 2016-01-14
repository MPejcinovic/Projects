using DiplomskiProjekt.Algorithms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiProjekt
{
    public class DigitalEnvelope
    {
        private AES _aes;
        private RSA _rsa;

        public AES AesClass 
        {
            get 
            {
                return _aes;
            }
            set 
            {
                _aes = value;
            }
        }

        public RSA Rsa 
        {
            get
            {
                return _rsa;
            }
            set 
            {
                _rsa = value;
            }
        }
        public DigitalEnvelope(AES aes, RSA rsa)
        {
            AesClass = aes;
            Rsa = rsa;
        }
        public void CreateDigitalEnvelope(string text, string name)
        {
            byte[] encryptedMessage = AesClass.EncryptString(text);
            byte[] encryptedKey = Rsa.Encrypt(Convert.ToBase64String(AesClass.Key));

            FileManager.WriteToXmlFile(name, Convert.ToBase64String(encryptedMessage));
            FileManager.WriteToXmlFile("IV", Convert.ToBase64String(AesClass.IV));
            FileManager.WriteToXmlFile("Key", Convert.ToBase64String(encryptedKey));
        }

        public string OpenDigitalEnvelope(string name)
        {
            var message = FileManager.ReadFromXMLFile(name);
            var key = FileManager.ReadFromXMLFile("Key");
            var iv = FileManager.ReadFromXMLFile("IV");

            byte[] encryptedMessage = Convert.FromBase64String(message);
            byte[] encryptedKey = Convert.FromBase64String(key);
            byte[] encryptedIv = Convert.FromBase64String(iv);

            byte[] aesKey = Convert.FromBase64String(Rsa.Decrypt(encryptedKey));
            string plainText = AesClass.DecryptString(encryptedMessage, aesKey, encryptedIv);

            return plainText;
        }
    }
}
