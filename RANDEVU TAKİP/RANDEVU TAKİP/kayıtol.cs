using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RANDEVU_TAKİP
{
    public partial class kayıtol : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-OLCHKHQ\\SQLEXPRESS; Initial Catalog=randevu_takip; Integrated Security=True;");
        public kayıtol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO kullanicilar (kullanici_ad,kullanici_sifre) values('"+textBox2.Text+"','"+textBox1.Text+"')",baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("tebrikler başarılı bir şekilde kayıt oldunuz");
          

        }
    }
}
