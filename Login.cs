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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool sifreac = true;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (sifreac)
            {
                sifreac = false;
                pictureBox1.Image = Image.FromFile("c:\\Users\\Nitro\\source\\repos\\Avtomobil salonları Informasiya Sistemleri Lab işi\\Resources\\eye.png");
                textBox2.UseSystemPasswordChar = false;
            }
            else if (!sifreac)
            {
                sifreac = true;
                pictureBox1.Image = Image.FromFile("c:\\Users\\Nitro\\source\\repos\\Avtomobil salonları Informasiya Sistemleri Lab işi\\Resources\\closed-eye.png");
                textBox2.UseSystemPasswordChar = true;
            }
        }
        SqlConnection baglanti = new SqlConnection("Data Source = BAHACER; Initial Catalog = AutoServices; Integrated Security = True");
        private void button2_Click(object sender, EventArgs e)
        {
            String username, password;
            username = textBox1.Text;
            password = textBox2.Text;

            try
            {
                String query = "SELECT * FROM Users WHERE Username ='" + textBox1.Text + "' AND Password ='" + textBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count>0)
                {
                    username = textBox1.Text;
                    password = textBox2.Text;

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();

                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
    }

