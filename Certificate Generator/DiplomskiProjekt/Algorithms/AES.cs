using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiProjekt.Algorithms
{
    public class AES
    {
        private Aes _aes = null;
        private byte[] _key;
        private byte[] _iv;

        public byte[] Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        public byte[] IV
        {
            get
            {
                return _iv;
            }
            set
            {
                _iv = value;
            }
        }
        public Aes AESSingleton
        {
            get
            {
                if (_aes == null)
                {
                    _aes = Aes.Create();
                }
                return _aes;
            }
        }
        public AES()
        {
            Key = AESSingleton.Key;
            IV = AESSingleton.IV;
        }

        public byte[] EncryptString(string plainText)
        {
            byte[] encrypted;

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentException("Data for encryption is not provided!");

            ICryptoTransform encryptor = AESSingleton.CreateEncryptor(Key, IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }
                    encrypted = memoryStream.ToArray();
                }
            }
            return encrypted;
        }

        public string DecryptString(byte[] cipherText, byte[] key, byte[] iv)
        {
            string plaintext = "";

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("Data for decryption is not provided!");

            ICryptoTransform decryptor = AESSingleton.CreateDecryptor(key, iv);
            using (MemoryStream memoryStream = new MemoryStream(cipherText))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        plaintext = streamReader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
