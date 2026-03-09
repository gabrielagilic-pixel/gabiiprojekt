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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUnos f = new FormUnos();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPregled f = new FormPregled();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormFiltriranje f = new FormFiltriranje();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormUdomljavanje f = new FormUdomljavanje();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormStatistika f = new FormStatistika();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
