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
    public partial class Services_Search : Form
    {
        public Services_Search()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = BAHACER; Initial Catalog = AutoServices; Integrated Security = True");
        public void axtar()
        {
            baglanti.Open();
            //Sorğu yaratmaq
            string query = @"USE AutoServices SELECT * FROM Services WHERE Service_ID LIKE N'"+textBox1.Text+"%'AND Service_Name LIKE N'" + textBox2.Text + "%'AND Service_Owner LIKE N'" + textBox3.Text + "%'AND Service_Number LIKE N'" + textBox4.Text + "%' AND Employee_Count LIKE N'"+textBox5.Text+"%' AND Service_Address LIKE N'" + textBox6.Text + "%'";

            //SqlCommand obyektini təyin edək
            SqlCommand cmd = new SqlCommand(query, baglanti);


            //SqlDataAdapter obyektini təyin edək 
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

            //DaataSeti müəyyənləşdirək
            DataSet ds = new DataSet();

            //Dataseti sorğu nəticələri ilə dolduraq
            dAdapter.Fill(ds);

            //DataGridView nəzarətini yalnız oxumaq üçün təyin edək
            dataGridView1.ReadOnly = true;

            //DataGridView nəzarətinin məlumat mənbəyini/məlumat cədvəlini təyin edək
            dataGridView1.DataSource = ds.Tables[0];


            //Bağlantını bağlayaq
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Services_Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'services._Services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.services._Services);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }
    }
}
