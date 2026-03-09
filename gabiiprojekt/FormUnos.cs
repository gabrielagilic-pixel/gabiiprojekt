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
                radioButton1.Checked + "," +
                radioButton2.Checked + "," +
                numericUpDown1.Value + "," +
                dateTimePicker1.Value + "," +
                checkBox1.Checked + "," +
                checkBox2.Checked + "," +
                txtNapomena.Text;
            Admin.Spremi(zapis);
        }
    }
}
