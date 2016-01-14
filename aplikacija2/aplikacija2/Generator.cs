using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace aplikacija2
{
    class Generator
    {
        public static void generiraj(int broj) 
        {
            System.Random RandNum = new System.Random();
            Random r = new Random();
            string choice = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@()?*=%&$#/";
 
            StreamWriter file = new StreamWriter(@"C:\\Users\\Matea\\Desktop\\file.txt");
            char el;


            for (int j = 0; j < broj; j++ ){
                string element;
                StringBuilder zapis = new StringBuilder();
                for (int i = 0; i < RandNum.Next(1, 14); i++)
                {
                    el = choice[r.Next(choice.Length)];
                    zapis.Append(el);
                }
                element = zapis.ToString();
                
                file.WriteLine(element);
               
            }
            file.Close();
        }
    }
}
