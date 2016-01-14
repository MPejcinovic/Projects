using DiplomskiProjekt.Algorithms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiProjekt
{
    public class DigitalSignature
    {
        private string _message;
        private string _key;
        private SHA3 _sha3;
        private RSA _rsa;

        public string Message 
        {
            get 
            {
                //return ConfigurationManager.AppSettings["Message"];
                return FileManager.ReadFromXMLFile("Message");
            }
        }

        public string Key 
        {
            get 
            {
                //return ConfigurationManager.AppSettings["Key"];
                return FileManager.ReadFromXMLFile("Key");
            }
        }

        public SHA3 Sha3 
        {
            get
            {
                return _sha3;
            }
            set 
            {
                _sha3 = value;
            }
        }

        public RSA RSAClass 
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
        public DigitalSignature(SHA3 sha3, RSA rsa)
        {
            Sha3 = sha3;
            RSAClass = rsa;
        }

        public string GetHash()
        {
            //FileManager.ChangeAppConfig("Hash", Sha3.Hash);
            FileManager.WriteToXmlFile("Hash", Sha3.Hash);
            return Sha3.Hash;
        }


        public string CheckDigitalSignature(string hashToCheck, string plainText)
        {
            //string message = ConfigurationManager.AppSettings["Message"];
            
            Sha3.ComputeHash(plainText);
            //string hashedMessage = GetHash();
            if (Sha3.Hash.Equals(hashToCheck))
            {
                return "Poruka je besprijekorna";
            }
            return "Poruka nema integriteta";
        }

    }
}
