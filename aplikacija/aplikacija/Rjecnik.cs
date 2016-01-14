using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aplikacija
{
    class Rjecnik
    {
        public static int Provjera(String zaporka) 
        {
            foreach (string line in File.ReadLines("C:\\Users\\Matea\\Documents\\Visual Studio 2013\\Projects\\aplikacija\\NajgoreZaporke.txt"))
                if (line.Contains(zaporka))
                    return 1;
                else 
                    continue;
            foreach (string line in File.ReadLines("C:/Users/Matea/Documents/Visual Studio 2013/Projects/aplikacija/Dictionary.txt"))
                if (line.Contains(zaporka))
                    return 2;
                else
                    continue;
            return 0;
        }
    }
}
