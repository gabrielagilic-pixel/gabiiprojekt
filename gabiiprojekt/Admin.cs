using gabiiprojekt.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gabiiprojekt
{
    internal class Admin
    {

        public static void Spremi(string zapis)
        {
            StreamWriter sr = new StreamWriter("Animals.txt", true);
            sr.WriteLine(zapis);
            sr.Close();

        }
        //zamjenjujemo  ravne linije (|) sa prazninom i zarezom
        public static List<string> GetAllAsStrings()
        {
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader("Animals.txt");
            string linija=sr.ReadLine();
            while (linija != null)
            {
                linija = linija.Replace(',', ' ');
                list.Add(linija);
                linija = sr.ReadLine();
            }
            return list;
        }

        public static void SpremiUdomljavanje(string zapis)
        {
            // Spremit ćemo u posebnu datoteku "Udomljavanja.txt"
            using (StreamWriter sw = new StreamWriter("Udomljavanja.txt", true))
            {
                sw.WriteLine(zapis);
            }
        }
        public static List<string> GetRawAnimals()
        {
            List<string> list = new List<string>();
            if (File.Exists("Animals.txt"))
            {
                list.AddRange(File.ReadAllLines("Animals.txt"));
            }
            return list;
        }

        public static int GetUdomljeniCount()
        {
            if (File.Exists("Udomljavanja.txt"))
            {
                return File.ReadAllLines("Udomljavanja.txt").Length;
            }
            return 0;
        }


    }
    
}
