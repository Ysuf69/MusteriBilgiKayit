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

namespace Corumlu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BaglantiSinif bgl = new BaglantiSinif();
        

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            //textBox10.Clear();
            richTextBox1.Clear();
        }

        SqlConnection baglan = new SqlConnection("Server=SARI;initial Catalog=Corumlu;integrated Security=true");
      

        public void verilerigoster(string veriler)
        {
            SqlConnection baglan = new SqlConnection("Server=SARI;initial Catalog=Corumlu;integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            da.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dataGridView1.DataSource = bs;

            this.dataGridView1.Columns["id"].Visible = false;

            bs.Sort = "Tarih desc";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
                label14.Text = i.ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            verilerigoster("select * from MotorProje");
            label16.Visible = false;
            textBox10.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=SARI;initial Catalog=Corumlu;integrated Security=true");
            baglan.Open();
            DialogResult cevap = MessageBox.Show("Veri eklemek istediğinize eminmisiniz ?", "Veri ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cevap==DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("insert into MotorProje (Tarih,Plaka,Ad,Marka,Model,Renk,Km,Yapılacaklar,ServisNot,Telefon,YapılanBakım) values (@Tarihh,@Plakaa,@Add,@Markaa,@Modell,@Renkk,@Kmm,@Yapılacaklarr,@ServisNott,@Telefonn,@YapılanBakımm)", baglan);
                komut.Parameters.AddWithValue("@Tarihh",Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString());
                komut.Parameters.AddWithValue("@Plakaa", textBox1.Text);
                komut.Parameters.AddWithValue("@Add", textBox2.Text);
                komut.Parameters.AddWithValue("@Markaa", textBox3.Text);
                komut.Parameters.AddWithValue("@Modell", textBox4.Text);
                komut.Parameters.AddWithValue("@Renkk", textBox9.Text);
                komut.Parameters.AddWithValue("@Kmm", textBox8.Text);
                komut.Parameters.AddWithValue("@Yapılacaklarr", textBox7.Text);
                komut.Parameters.AddWithValue("@ServisNott", textBox6.Text);
                komut.Parameters.AddWithValue("@Telefonn", textBox5.Text);
                komut.Parameters.AddWithValue("@YapılanBakımm", richTextBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kaydınız başarıyla eklendi!");
                temizle();
            }
            else
            {

            }
            verilerigoster("select * from MotorProje");
            baglan.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=SARI;initial Catalog=Corumlu;integrated Security=true");
            baglan.Open();
            SqlCommand komut = new SqlCommand("update MotorProje set  Tarih='" + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString() + "',Ad='" + textBox2.Text + "',Marka='" + textBox3.Text + "',Model='" + textBox4.Text + "',Renk='" + textBox9.Text + "',Km='" + textBox8.Text + "',Yapılacaklar='" + textBox7.Text + "',ServisNot='" + textBox6.Text + "',Telefon='" + textBox5.Text + "',Plaka='" + textBox1.Text + "',YapılanBakım='" + richTextBox1.Text + "' where id='" + textBox10.Text + "'", baglan);
            komut.ExecuteNonQuery();
            verilerigoster("select * from MotorProje");
            baglan.Close();
            MessageBox.Show("Kaydınız başarıyla güncellendi!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string Tarih = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string Plaka = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string Ad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string Marka = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string Model = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string Renk = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string Km = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string Yapılacaklar = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            string ServisNot = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            string Telefon = dataGridView1.Rows[secilialan].Cells[9].Value.ToString();
            string YapılanBakım = dataGridView1.Rows[secilialan].Cells[10].Value.ToString();
            string id = dataGridView1.Rows[secilialan].Cells[11].Value.ToString();

            dateTimePicker1.Text = Tarih;
            textBox1.Text = Plaka;
            textBox2.Text = Ad;
            textBox3.Text = Marka;
            textBox4.Text = Model;
            textBox9.Text = Renk;
            textBox8.Text = Km;
            textBox7.Text = Yapılacaklar;
            textBox6.Text = ServisNot;
            textBox5.Text = Telefon;
            richTextBox1.Text = YapılanBakım;
            textBox10.Text = id;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=SARI;initial Catalog=Corumlu;integrated Security=true");
            baglan.Open();
            DialogResult cevap = MessageBox.Show("Silmek istediğinize eminmisiniz", "Silme İtemi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cevap == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from MotorProje where Ad=@Add", baglan);
                komut.Parameters.AddWithValue("@Add", textBox2.Text);
                komut.ExecuteNonQuery();
                SqlCommand sqlCommand = new SqlCommand("delete from MotorProje where Ad=@Add", baglan);
                MessageBox.Show("Kaydınız başarıyla silindi!");
                temizle();
            }
            else
            {

            }
            verilerigoster("select * from MotorProje");
            baglan.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from MotorProje");
            textBox12.Clear();
            textBox13.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=SARI;initial Catalog=Corumlu;integrated Security=true");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from MotorProje where Ad like '%" + textBox12.Text + "%'", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
            
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=SARI;initial Catalog=Corumlu;integrated Security=true");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from MotorProje where Plaka like '%" + textBox13.Text + "%'", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
