using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gabiiprojekt
{
    public partial class FormStatistika : Form
    {
        public FormStatistika()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            List<string> sveZivotinje = Admin.GetRawAnimals();
            int udomljeniCount = Admin.GetUdomljeniCount();

            int ukupnoZivotinja = sveZivotinje.Count;
            int trenutnoPrisutno = ukupnoZivotinja - udomljeniCount;

            double sumaGodina = 0;
            int brojPasa = 0;
            int brojMacaka = 0;
            int brojKonja = 0;
            int brojZmija = 0;
            int brojHrcaka = 0;
            int brojMiseva = 0;

            foreach (string redak in sveZivotinje)
            {
                string[] dijelovi = redak.Split(',');
                if (dijelovi.Length >= 5)
                {
                    // Brojanje po vrstama
                    string vrsta = dijelovi[1].ToLower().Trim();
                    if (vrsta.Contains("pas")) brojPasa++;
                    else if (vrsta.Contains("macka") || vrsta.Contains("mačka")) brojMacaka++;
                    else if (vrsta.Contains("zmija") || vrsta.Contains("zmija")) brojZmija++;
                    else if (vrsta.Contains("hrčak") || vrsta.Contains("hrčak")) brojHrcaka++;
                    else if (vrsta.Contains("miš") || vrsta.Contains("miš")) brojMiseva++;
                    else if (vrsta.Contains("konj")) brojKonja++;

                    // Zbrajanje godina za prosjek
                    if (double.TryParse(dijelovi[4], out double dob))
                    {
                        sumaGodina += dob;
                    }
                }
            }

            double prosjekDobi = ukupnoZivotinja > 0 ? sumaGodina / ukupnoZivotinja : 0;

            // Ispis u ListBox, ovo će biti vidljivo u ListBoxu unutar forme
            listBox1.Items.Add($"--- STATISTIKA AZILA ---");
            listBox1.Items.Add($"Ukupan broj unesenih životinja: {ukupnoZivotinja}");
            listBox1.Items.Add($"Broj udomljenih životinja: {udomljeniCount}");
            listBox1.Items.Add($"Trenutno prisutno u azilu: {trenutnoPrisutno}");
            listBox1.Items.Add($"Prosječna dob životinja: {prosjekDobi:F2} god.");
            listBox1.Items.Add($"------------------------");
            listBox1.Items.Add($"Broj pasa: {brojPasa}");
            listBox1.Items.Add($"Broj mačaka: {brojMacaka}");
            listBox1.Items.Add($"Broj zmija: {brojZmija}");
            listBox1.Items.Add($"Broj hrčaka: {brojHrcaka}");
            listBox1.Items.Add($"Broj miševa: {brojMiseva}");
            listBox1.Items.Add($"Broj konja: {brojKonja}");
        }
    }
}
