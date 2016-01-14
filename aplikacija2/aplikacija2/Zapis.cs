using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace aplikacija2
{
    class Zapis
    {
        public static void hashing() 
        {
            List<String> pisi = new List<String>();
            StreamWriter zapis = null;
            StreamWriter dat = new StreamWriter(@"C:\\Users\\Matea\\Desktop\\dat.txt");
            StreamWriter datic = new StreamWriter(@"C:\\Users\\Matea\\Desktop\\rjecnik.txt");
 
            foreach (string line in File.ReadLines("C:\\Users\\Matea\\Documents\\Visual Studio 2013\\Projects\\aplikacija\\Dictionary.txt")) 
            {
                string value = Hash.izracun(line,null);
                dat.WriteLine(value + "          " + line);
                datic.WriteLine(value);
            }

            dat.Close();
            datic.Close();
            foreach (string line in File.ReadLines("C:\\Users\\Matea\\Desktop\\rjecnik.txt"))
            {
                string a = Check.provjeri(line);
                if (!(a.Equals("")))
                {
                    pisi.Add(a);
                }
            }
            zapis = new StreamWriter(@"C:\\Users\\Matea\\Desktop\\zapis.txt");
            System.Console.WriteLine("Ovo je pisi:");
            foreach (object o in pisi)
            {
                System.Console.WriteLine(o);
                zapis.WriteLine(o);
            }
            zapis.Flush();
            zapis.Close();
            
        }
    }
}
