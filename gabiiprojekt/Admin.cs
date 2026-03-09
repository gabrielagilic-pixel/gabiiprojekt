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
    }
}
