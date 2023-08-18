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
    public partial class Cars_UAD : Form
    {
        public Cars_UAD()
        {
            InitializeComponent();
        }

        private void Cars_UED_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cars._Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.cars._Cars);

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
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //--------------------------------ElaveEt---------------------------------

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Insert into Cars (Service_ID,Car_Owner,Car_Manufacturer,Car_Name,Production_Year,Car_Engine,Fuel_Type,Car_Problem) values(@sid,@own,@manu,@name,@year,@eng,@fuel,@prob)", baglanti);
            cmd.Parameters.AddWithValue("@sid", textBox1.Text);
            cmd.Parameters.AddWithValue("@own", textBox2.Text);
            cmd.Parameters.AddWithValue("@manu", textBox3.Text);
            cmd.Parameters.AddWithValue("@name", textBox4.Text);
            cmd.Parameters.AddWithValue("@year", textBox5.Text);
            cmd.Parameters.AddWithValue("@eng", textBox6.Text);
            cmd.Parameters.AddWithValue("@fuel", textBox7.Text);
            cmd.Parameters.AddWithValue("@prob", textBox8.Text);

            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter("select * from Cars", baglanti);
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
                SqlCommand cmd_update = new SqlCommand("Update Cars set Service_ID=@sid, Car_Owner=@own, Car_Manufacturer=@manu, Car_Name=@name, Production_Year=@year, Car_Engine=@eng, Fuel_Type=@fuel, Car_Problem=@prob where Car_ID=@id", baglanti);
                cmd_update.Parameters.AddWithValue("@sid", textBox1.Text);
                cmd_update.Parameters.AddWithValue("@own", textBox2.Text);
                cmd_update.Parameters.AddWithValue("@manu", textBox3.Text);
                cmd_update.Parameters.AddWithValue("@name", textBox4.Text);
                cmd_update.Parameters.AddWithValue("@year", textBox5.Text);
                cmd_update.Parameters.AddWithValue("@eng", textBox6.Text);
                cmd_update.Parameters.AddWithValue("@fuel", textBox7.Text);
                cmd_update.Parameters.AddWithValue("@prob", textBox8.Text);
                cmd_update.Parameters.AddWithValue("@id", id);

                cmd_update.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter("select * from Cars", baglanti);
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
                SqlCommand cmd_sil = new SqlCommand("delete from Cars where Car_ID=@id", baglanti);
                cmd_sil.Parameters.AddWithValue("@id", id);
                cmd_sil.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter("select * from Cars", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti.Close();
                MessageBox.Show("Məlumatlar bazadan silindi", "Məlumat");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
    }
}
