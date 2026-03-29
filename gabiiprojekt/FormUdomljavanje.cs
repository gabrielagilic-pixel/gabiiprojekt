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
    public partial class FormUdomljavanje : Form
    {
        public FormUdomljavanje()
        {
            InitializeComponent();
            printPreviewDialog1.Document = printDocument1; // Ovo povezuje prozor s papirom
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Validacija - provjera jesu li polja prazna
            if (string.IsNullOrWhiteSpace(textBox1.Text) || !maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Molimo unesite ime udomitelja i potpun broj telefona!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Priprema podataka za zapis
            // Koristimo .ToShortDateString() da datum bude pregledan (npr. 29.3.2026.)
            string datum = dateTimePicker1.Value.ToShortDateString();
            string udomitelj = textBox1.Text;
            string kontakt = maskedTextBox1.Text;

            // Spajamo u jedan redak sa zarezima (kao što si radila i ranije)
            string zapis = $"{datum},{udomitelj},{kontakt}";

            // Slanje u klasu Admin (ovdje ćemo dodati novu metodu SpremiUdomljavanje)
            Admin.SpremiUdomljavanje(zapis);

            // Povratna informacija i čišćenje
            MessageBox.Show("Udomljavanje je uspješno zabilježeno!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Clear();
            maskedTextBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Prikaži predpregled prije ispisa
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            // Fontovi za ispis
            Font naslovFont = new Font("Arial", 20, FontStyle.Bold);
            Font tekstFont = new Font("Arial", 12, FontStyle.Regular);
            Font potpisFont = new Font("Arial", 10, FontStyle.Italic);

            // Podaci s forme
            string datum = dateTimePicker1.Value.ToShortDateString();
            string udomitelj = textBox1.Text;
            string kontakt = maskedTextBox1.Text;

            // Crtanje sadržaja na papir (koordinate X, Y)
            e.Graphics.DrawString("POTVRDA O UDOMLJAVANJU", naslovFont, Brushes.Black, 150, 100);
            e.Graphics.DrawLine(Pens.Black, 100, 140, 700, 140); // Crta ispod naslova

            e.Graphics.DrawString($"Datum udomljavanja: {datum}", tekstFont, Brushes.Black, 100, 200);
            e.Graphics.DrawString($"Udomitelj: {udomitelj}", tekstFont, Brushes.Black, 100, 240);
            e.Graphics.DrawString($"Kontakt telefon: {kontakt}", tekstFont, Brushes.Black, 100, 280);

            e.Graphics.DrawString("Ovim se potvrđuje da je gore navedeni udomitelj preuzeo", tekstFont, Brushes.Black, 100, 350);
            e.Graphics.DrawString("brigu o životinji iz azila te se obvezuje na human odnos.", tekstFont, Brushes.Black, 100, 375);

            // Mjesto za potpise
            e.Graphics.DrawLine(Pens.Black, 100, 550, 300, 550);
            e.Graphics.DrawString("Potpis udomitelja", potpisFont, Brushes.Black, 140, 560);

            e.Graphics.DrawLine(Pens.Black, 500, 550, 700, 550);
            e.Graphics.DrawString("Potpis ovlaštene osobe", potpisFont, Brushes.Black, 520, 560);

            // Opcionalno: Možeš dodati i mali logo ili pečat ako imaš sliku
            // e.Graphics.DrawImage(pictureBox1.Image, 100, 600, 100, 100);
        }

    }
}
