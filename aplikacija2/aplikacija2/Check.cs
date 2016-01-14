using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace aplikacija2
{
    class Check
    {

        public static string provjeri(String line)
        {
            foreach (string linija in File.ReadLines("C:\\Users\\Matea\\Desktop\\file.txt"))
            {
                byte[] novi = Convert.FromBase64String(line);

                if (novi.Length < 16)
                {
                    continue;
                }
                else
                {
                    byte[] salt = new byte[novi.Length - 16];

                    for (int i = 0; i < salt.Length; i++)
                    {
                        salt[i] = novi[16 + i];
                    }
                    string izlaz = Hash.izracun(linija, salt);
                    if (line.Equals(izlaz))
                    {
                        foreach (string e in File.ReadLines("C:\\Users\\Matea\\Desktop\\dat.txt"))
                        {
                            if (e.Contains(line))
                            {
                                return e;
                            }
                        }
                    }
                }
            }
            return "";
        }
    }
}
