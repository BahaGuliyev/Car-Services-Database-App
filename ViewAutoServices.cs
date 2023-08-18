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
    public partial class ViewAutoServices : Form
    {
        public ViewAutoServices()
        {
            InitializeComponent();
        }

        private void ViewAutoServices_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoServicesDataSet.View_AutoServices' table. You can move, or remove it, as needed.
            this.view_AutoServicesTableAdapter.Fill(this.autoServicesDataSet.View_AutoServices);

        }
        SqlConnection baglanti = new SqlConnection("Data Source = BAHACER; Initial Catalog = AutoServices; Integrated Security = True");
        public void axtar()
        {
            baglanti.Open();
            //Sorğu yaratmaq
            string query = @"USE AutoServices SELECT * FROM View_AutoServices WHERE Car_ID LIKE N'" + textBox1.Text + "%'AND Service_ID LIKE N'" + textBox2.Text + "%'AND Car_Owner LIKE N'" + textBox3.Text + "%'AND Car_Manufacturer LIKE N'" + textBox4.Text + "%' AND Car_Name LIKE N'" + textBox5.Text + "%' AND Production_Year LIKE N'" + textBox6.Text + "%' AND Car_Engine LIKE N'" + textBox7.Text + "%' AND Fuel_Type LIKE N'" + textBox8.Text + "%' AND Car_Problem LIKE N'" + textBox9.Text + "%' AND Service_Name LIKE N'" + textBox10.Text + "%' AND Service_Owner LIKE N'" + textBox11.Text + "%' AND Service_Number LIKE N'" + textBox12.Text + "%' AND Employee_Count LIKE N'" + textBox13.Text + "%' AND Service_Address LIKE N'" + textBox14.Text + "%'";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            axtar();
        }

        private void button1_Click(object sender, EventArgs e)
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
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }
    }
}
