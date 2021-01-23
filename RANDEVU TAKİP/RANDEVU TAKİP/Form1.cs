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
    public partial class Form1 : Form
    {
        
        SqlCommand komut;
        SqlDataAdapter da;
        
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-OLCHKHQ\\SQLEXPRESS; Initial Catalog=randevu_takip; Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {

            
            baglanti.Open();
            DateTime secilentarih = dateTimePicker2.Value;
            da = new SqlDataAdapter("SELECT  r.randevu_id,r.randev_tarihi,r.randevu_saati, h.adı,h.soyadı,h.tc_no,h.telefon_no,b.bolum_adı,d.doktor_adı,d.doktor_soyadı   FROM hastalar h,doktorlar d,randevular r,bolum b  WHERE b.bolum_id=r.bolum_id AND d.doktor_id=r.doktor_id AND h.hasta_id=r.hasta_id  AND  r.randev_tarihi='" + secilentarih.ToString("yyyyMMdd") + "' AND d.doktor_adı='"+comboBox1.Text+"'", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from bolum ", baglanti);
            DataTable tablo2 = new DataTable();
            adaptor.Fill(tablo2);
            bolumadları.ValueMember = "bolum_id";
            bolumadları.DisplayMember = "bolum_adı";
            bolumadları.DataSource = tablo2;
            baglanti.Close();

            komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM doktorlar";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr2;
            baglanti.Open();
            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["doktor_adı"]);
            }
            baglanti.Close();
            dr2.Close(); 


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            randevu_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            hastaad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            hastasoyad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            hastatc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            hastatel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            bolumadları.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            doktoradları.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hastaekle1 = "INSERT INTO hastalar(adı,soyadı,tc_no,telefon_no)Values(@adı,@soyadı,@tc,@tel)";
           string randevutarih = "UPDATE randevular SET randev_tarihi=@tarih,randevu_saati=@saat WHERE randevu_id=(select randevu_id from kayitguncelle) ";
            string ıdekle = "INSERT INTO randevular(bolum_id ,doktor_id,hasta_id)SELECT bolum_id ,doktor_id, hasta_id  FROM doktorlar, bolum , hastalar where tc_no='" + hastatc.Text + "' AND bolum_adı='" + bolumadları.Text + "' AND doktor_adı = '" + doktoradları.Text + "'";
           SqlCommand komut = new SqlCommand(hastaekle1, baglanti);
           SqlCommand komut3 = new SqlCommand(randevutarih, baglanti);
           SqlCommand komut2 = new SqlCommand(ıdekle, baglanti);
            komut.Parameters.AddWithValue("@adı", hastaad.Text);
            komut.Parameters.AddWithValue("@soyadı", hastasoyad.Text);
            komut.Parameters.AddWithValue("@tc", hastatc.Text);
            komut.Parameters.AddWithValue("@tel", hastatel.Text);
            komut3.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            komut3.Parameters.AddWithValue("@saat", maskedTextBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            komut3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            DateTime girilentarih = dateTimePicker1.Value;
            DateTime secilentarih = dateTimePicker2.Value;
            da = new SqlDataAdapter("SELECT  r.randevu_id,r.randev_tarihi,r.randevu_saati, h.adı,h.soyadı,h.tc_no,h.telefon_no,b.bolum_adı,d.doktor_adı,d.doktor_soyadı   FROM hastalar h,doktorlar d,randevular r,bolum b  WHERE b.bolum_id=r.bolum_id AND d.doktor_id=r.doktor_id AND h.hasta_id=r.hasta_id  AND  r.randev_tarihi='" + secilentarih.ToString("yyyyMMdd") + "' AND d.doktor_adı='" + comboBox1.Text + "'", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu= "DELETE FROM randevular where randevu_id=@id";    
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id",Convert.ToInt32(randevu_no.Text));
       
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            DateTime secilentarih = dateTimePicker2.Value;
            da = new SqlDataAdapter("SELECT  r.randevu_id,r.randev_tarihi,r.randevu_saati, h.adı,h.soyadı,h.tc_no,h.telefon_no,b.bolum_adı,d.doktor_adı,d.doktor_soyadı   FROM hastalar h,doktorlar d,randevular r,bolum b  WHERE b.bolum_id=r.bolum_id AND d.doktor_id=r.doktor_id AND h.hasta_id=r.hasta_id  AND  r.randev_tarihi='" + secilentarih.ToString("yyyyMMdd") + "' AND d.doktor_adı='" + comboBox1.Text + "'", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

       

        private void menugit_Click(object sender, EventArgs e)
        {
            menu menugit = new menu();
            this.Hide();
            menugit.Show();
        }

        private void bolumadları_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bolumadları.SelectedIndex != -1)
            {
                SqlDataAdapter adaptor = new SqlDataAdapter("select * from doktorlar where doktor_bolumu = " + bolumadları.SelectedValue, baglanti);
                DataTable tablo = new DataTable();
                
                adaptor.Fill(tablo);
                doktoradları.ValueMember= "doktor_id";
                doktoradları.DisplayMember = "doktor_adı";
                doktoradları.DataSource = tablo;
            }
        }
    }
    
}
