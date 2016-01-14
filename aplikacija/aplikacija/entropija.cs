using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace aplikacija
{
    public class entropija
    {
        // zaporka is value for evaluation
        public static double[] Ulaz(string zaporka)
        {
            Dictionary<char, double> rjecnik = new Dictionary<char, double>();
            double ent = 0.0;
            int i = 0;
            int a = 0;
            int L = 0;
            double entrophy = 0.0;
            bool VELIKA_SLOVA = false;
            bool MALA_SLOVA = false;
            bool BROJEVI = false;
            bool ZNAKOVI = false;
            double[] polje = new double[2];

            string ulaz = zaporka;

            int brojac = ulaz.Length;

            // adding every character to dictionary rjecnik (only once)
            foreach(char znak in ulaz)
            {
                if (rjecnik.ContainsKey(znak)==false)
                {
                    rjecnik.Add(znak,1);
                    a++;
                }
                    
                else
                    rjecnik[znak]++;

                //figuring out what type of character is current char
                if ("abcdefghigklmnopqrstuvwxyz".Contains(znak) && MALA_SLOVA == false)
                {
                    L+=26;
                    MALA_SLOVA=true;
                }
                else if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(znak) && VELIKA_SLOVA == false)
                {
                    L+=26;
                    VELIKA_SLOVA = true;
                }
                else if ("0123456789".Contains(znak) && BROJEVI == false)
                {
                    L+=10;
                    BROJEVI = true;
                }
                else if ("!#$%&'()*+,-./:;<=>?@[]^_`{|}~\\\" ".Contains(znak) && ZNAKOVI == false)
                {
				L += 33; 
				ZNAKOVI = true;
                }
            }

            double[] poljeVjerojatnosti = new double[a];

            // calculating probability for every character =) 
            foreach (char j in rjecnik.Keys) 
            {
                poljeVjerojatnosti[i] = rjecnik[j] / (double)brojac;
                i++;
            }

            //calculation of entrophy for inserted password
            for (int k = 0; k < a; k++)
                entrophy -= poljeVjerojatnosti[k]*(Math.Log(poljeVjerojatnosti[k]) / Math.Log(2));

            ent = L * entrophy;
            polje[0] = Math.Round(entrophy, 3);
            polje[1] = Math.Round(ent, 3);
            return polje;
        }
    }
}