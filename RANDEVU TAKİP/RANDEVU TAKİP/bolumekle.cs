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
    public partial class bolumekle : Form
    {
        SqlCommand komut;
        SqlDataAdapter da;
        public bolumekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-OLCHKHQ\\SQLEXPRESS; Initial Catalog=randevu_takip; Integrated Security=True;");

        private void menugit_Click(object sender, EventArgs e)
        {
            menu menugit = new menu();
            this.Hide();
            menugit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bolum ekle 
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO bolum (bolum_adı) values('" + textBox1.Text + "')", baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("tebrikler başarılı bir şekilde bölüm eklenmiştir ");
            da = new SqlDataAdapter("SELECT * FROM bolum", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void bolumekle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string goster = "SELECT * FROM bolum ";
            SqlCommand komut = new SqlCommand(goster, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM bolum where bolum_adı=@bolum_adı";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@bolum_adı",textBox1.Text);
            

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            da = new SqlDataAdapter("SELECT * FROM bolum", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }
    }
}
