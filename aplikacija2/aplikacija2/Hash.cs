using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace aplikacija2
{
    class Hash
    {
        public static String izracun(String tekst, byte[] salt)
        {
            if (salt == null)
            {
                Random random = new Random();
                salt = new byte[random.Next(4, 8)];
                RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
                r.GetNonZeroBytes(salt);
            }

            byte[] polje = Encoding.UTF8.GetBytes(tekst);
            int duljina1 = polje.Length;
            int duljina2 = salt.Length;
            byte[] hash = new byte[duljina1 + duljina2];

            for (int i = 0; i < duljina1; i++)
                hash[i] = polje[i];

            for (int i = 0; i < duljina2; i++)
                hash[i + duljina1] = salt[i];

            HashAlgorithm alg = new MD5CryptoServiceProvider();

            byte[] zapis = alg.ComputeHash(hash);
            int duljina3 = zapis.Length;
            byte[] saltiraniZapis = new byte[duljina2 + duljina3];

            for (int i = 0; i < duljina3; i++)
                saltiraniZapis[i] = zapis[i];
            for (int i = 0; i < duljina2; i++)
                saltiraniZapis[i + duljina3] = salt[i];

            string vrijednost = Convert.ToBase64String(saltiraniZapis);

            return vrijednost;
        }
    }
}
