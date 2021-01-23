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
    public partial class giris : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public giris()
        {
            InitializeComponent();
        }
          

        private void giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayıtol kayıtol = new kayıtol();
            kayıtol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string kullanici = textBox2.Text;
            string sifre = textBox1.Text;
            con = new SqlConnection("Server=DESKTOP-OLCHKHQ\\SQLEXPRESS; Initial Catalog=randevu_takip; Integrated Security=True;");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kullanicilar WHERE kullanici_ad='"+textBox2.Text+ "' AND kullanici_sifre='"+textBox1.Text+"'  ";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(" giriş başarılı");
                this.Hide();
                menu menu = new menu();
                menu.Show();
               

            }
            else
            {
                MessageBox.Show("kullanıcı adını veya şifreyi kontrol ediniz");
            }

            con.Close();
            
            


        }
    }
}
