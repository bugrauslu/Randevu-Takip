using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANDEVU_TAKİP
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doktorekle dktrekle = new doktorekle();
            dktrekle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bolumekle bolumekle = new bolumekle();
            bolumekle.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 randevu = new Form1();
            randevu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kayıtol kayıtol = new kayıtol();
            kayıtol.Show();
        }
    }
}
