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
    public partial class FormFiltriranje : Form
    {
        public FormFiltriranje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // 1. Očisti listu prije novog prikaza
            listBox1.Items.Clear();

            // 2. Provjera je li išta odabrano
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite vrstu životinje iz popisa!");
                return;
            }

            // Uzimamo odabranu vrstu iz ComboBox-a (npr. "Zmija")
            string odabranaVrsta = comboBox1.SelectedItem.ToString().ToLower().Trim();

            // 3. Dohvati sirove podatke iz klase Admin (oni koji imaju zareze)
            List<string> sveLinije = Admin.GetRawAnimals();

            foreach (string linija in sveLinije)
            {
                // 4. Razbijamo liniju na dijelove pomoću zareza
                string[] polja = linija.Split(',');

                // Provjeravamo ima li linija barem dva polja (Ime i Vrsta)
                if (polja.Length > 1)
                {
                    // VRSTA je uvijek na drugom mjestu (indeks 1)
                    string vrstaIzDatoteke = polja[1].ToLower().Trim();

                    // 5. STROGA PROVJERA: Mora biti identično onome iz ComboBox-a
                    if (vrstaIzDatoteke == odabranaVrsta)
                    {
                        // Dodajemo u listbox, ali zamijenimo zareze razmakom da izgleda ljepše
                        listBox1.Items.Add(linija.Replace(',', ' '));
                    }
                }
            }

            // 6. Ako nakon petlje nema ničega u listi
            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add("Nema pronađenih životinja za vrstu: " + odabranaVrsta);
            }
        }

        


        private void FormFiltriranje_Load(object sender, EventArgs e)
        {

        }
    }
}
