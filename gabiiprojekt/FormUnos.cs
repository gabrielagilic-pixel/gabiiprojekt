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
    public partial class FormUnos : Form
    {
        public FormUnos()
        {
            InitializeComponent();
        }
        //klikom na gumb spemamo sve podatke 
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIme.Text == "" || txtVrsta.Text == "" || txtPasmina.Text == "" || txtNapomena.Text == "")
            {
                MessageBox.Show("Svi podatci su spremljeni!");
                return;
            }
            string zapis =
                txtIme.Text + "," +
                txtVrsta.Text + "," +
                txtPasmina.Text + "," +
                radioButton1.Checked +"muško" +  "," +
                radioButton2.Checked + "žensko" + "," +
                numericUpDown1.Value + "," +
                dateTimePicker1.Value + "," +
                checkBox1.Checked + "," +
                checkBox2.Checked + "," +
                txtNapomena.Text;
            Admin.Spremi(zapis);

            MessageBox.Show("Podatci su uspješno spremljeni!");
            //Nakon što smo sve unjeli brišemo podatke o imenu, vrsti, pasmini i napomenu za životinju
            txtIme.Clear();
            txtVrsta.Clear();
            txtPasmina.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            numericUpDown1.Value = 0;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            txtNapomena.Clear();

        }

        private void FormUnos_Load(object sender, EventArgs e)
        {

        }
        // Varijabla na vrhu klase FormUnos koja će čuvati putanju odabrane slike
        string putanjaSlike = "";
        private void btnOdaberiSliku_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Filtriramo samo slikovne datoteke
                ofd.Filter = "Slike (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    putanjaSlike = ofd.FileName; // Sprema putanju u varijablu
                    pictureBox1.Image = Image.FromFile(putanjaSlike); // Prikazuje sliku
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Da slika stane u okvir
                }
            }
        
    }
    }
}
