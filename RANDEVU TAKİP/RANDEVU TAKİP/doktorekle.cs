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
    public partial class doktorekle : Form
    {
        SqlCommand komut;
        SqlDataAdapter da;
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-OLCHKHQ\\SQLEXPRESS; Initial Catalog=randevu_takip; Integrated Security=True;");
        public doktorekle()
        {
            InitializeComponent();
        }

        private void doktorekle_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            string goster = "SELECT doktor_adı,doktor_soyadı,doktor_bolumu FROM doktorlar ";
            SqlCommand komut = new SqlCommand(goster, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            baglanti.Close();
            

            komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM bolum";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr1;
            baglanti.Open();
            dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
               comboBox1.Items.Add(dr1["bolum_id"]);
            }
            baglanti.Close();
        }

        private void menugit_Click(object sender, EventArgs e)
        {
            menu menugit = new menu();
            this.Hide();
            menugit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //doktor ekleme
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO doktorlar (doktor_adı,doktor_soyadı,doktor_bolumu) values('" + textBox2.Text + "','"+textBox1.Text+"','"+ comboBox1.Text +"')", baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();

            da = new SqlDataAdapter("SELECT doktor_adı,doktor_soyadı,doktor_bolumu FROM doktorlar", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            MessageBox.Show(" başarılı bir şekilde doktor eklenmiştir ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //doktor silme
            string sorgu = "DELETE FROM doktorlar where doktor_soyadı=@doktor_soyadı";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@doktor_soyadı", textBox1.Text);
            

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            da = new SqlDataAdapter("SELECT doktor_adı,doktor_soyadı,doktor_bolumu FROM doktorlar", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
