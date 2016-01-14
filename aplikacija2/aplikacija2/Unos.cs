using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace aplikacija2
{
    class Unos
    {
        public static void unesi(int broj)
        {
            StreamWriter file = new StreamWriter(@"C:\\Users\\Matea\\Desktop\\file.txt");
            System.Console.WriteLine("Molim unesite zaporke za analizu");
            for (int i = 0; i < broj; i++)
            {
                file.WriteLine(Console.ReadLine());
            }
            file.Close();
        }
    }
}
