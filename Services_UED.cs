using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtomobil_salonları_Informasiya_Sistemleri_Lab_işi
{
    public partial class Services_UAD : Form
    {
        public Services_UAD()
        {
            InitializeComponent();
        }

        private void Services_UED_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'services._Services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.services._Services);

        }
        SqlConnection baglanti = new SqlConnection("Data Source = BAHACER; Initial Catalog = AutoServices; Integrated Security = True");
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //----------------------Melumatlarin eks olunmasi(Eger bosluq varsa kemiyyetler yazilmasin)
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //--------------------------------ElaveEt---------------------------------

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Insert into Services (Service_Name,Service_Owner,Service_Number,Employee_Count,Service_Address) values(@ad,@sahib,@nmr,@isci,@adrs)", baglanti);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@sahib", textBox2.Text);
            cmd.Parameters.AddWithValue("@nmr", textBox3.Text);
            cmd.Parameters.AddWithValue("@isci", textBox4.Text);
            cmd.Parameters.AddWithValue("@adrs", textBox5.Text);

            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter("select * from Services", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //--------------------------------RedakteEt---------------------------------
            if (MessageBox.Show("Məlumatları dəyişmək istədiyinizə əminsiniz?", "Doğrula", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                baglanti.Open();
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommand cmd_update = new SqlCommand("Update Services set Service_Name=@ad, Service_Owner=@sahib, Service_Number=@nmr, Employee_Count=@isci, Service_Address=@adrs where Service_ID=@id", baglanti);
                cmd_update.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd_update.Parameters.AddWithValue("@sahib", textBox2.Text);
                cmd_update.Parameters.AddWithValue("@nmr", textBox3.Text);
                cmd_update.Parameters.AddWithValue("@isci", textBox4.Text);
                cmd_update.Parameters.AddWithValue("@adrs", textBox5.Text);
                cmd_update.Parameters.AddWithValue("@id", id);

                cmd_update.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter("select * from Services", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti.Close();
                MessageBox.Show("Məlumatlar dəyişdi", "Məlumat");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //--------------------------------Sil---------------------------------
            if (MessageBox.Show("Məlumatları bazadan silmək istədiyinizə əminsiniz?", "Doğrula", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                baglanti.Open();
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommand cmd_sil = new SqlCommand("delete from Services where Service_ID=@id", baglanti);
                cmd_sil.Parameters.AddWithValue("@id", id);
                cmd_sil.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter("select * from Services", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti.Close();
                MessageBox.Show("Məlumatlar bazadan silindi", "Məlumat");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //-------------------melumatlari redakteden silmek-----------------------
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
