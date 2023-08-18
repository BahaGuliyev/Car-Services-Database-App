using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtomobil_salonları_Informasiya_Sistemleri_Lab_işi
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        Random rndm = new Random();
        string confCode;
        private void button1_Click(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Users WHERE Username ='" + textBox1.Text + "' OR Mail ='" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                if (textBox3.Text == textBox4.Text && textBox3.Text!="" && dt.Rows.Count == 0)
                {
                    confCode = rndm.Next(10000, 99999).ToString();
                    MailMessage sms = new MailMessage("autoserviceform@gmail.com", textBox2.Text, "Confirmation Code", "Code:" + confCode);
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential("autoserviceform@gmail.com", "autoservicepass");
                    smtpClient.Send(sms);
                    MessageBox.Show("Confirmation code was sent", "Info", MessageBoxButtons.OK);
                    panel1.Visible = true;
                }
                else if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Please make sure you fill in all the blanks!","Error");
                }
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Write password please!", "Error");
                }
                else if(dt.Rows.Count != 0)
                {
                    MessageBox.Show("Mail or Username is already used!", "Error");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Somethings gone wrong!", "Error");
            }

        }
        SqlConnection baglanti = new SqlConnection("Data Source = BAHACER; Initial Catalog = AutoServices; Integrated Security = True");

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text==confCode)
            {
                
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("Insert into Users (Username,Password,Mail) values(@usr,@psw,@mail)", baglanti);
                cmd.Parameters.AddWithValue("@usr", textBox1.Text);
                cmd.Parameters.AddWithValue("@mail", textBox2.Text);
                cmd.Parameters.AddWithValue("@psw", textBox3.Text);

                cmd.ExecuteNonQuery();
                baglanti.Close();
                
                DialogResult dialogResult=MessageBox.Show("You have successfully registered.", "Register",MessageBoxButtons.OK);
                if(dialogResult == DialogResult.OK)
                {
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("There was an error creating your account!", "Error");
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }
    }
}
