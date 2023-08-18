using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtomobil_salonları_Informasiya_Sistemleri_Lab_işi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void updateEditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form services_UED = new Services_UAD();
            services_UED.ShowDialog();
        }

        private void updateEditDeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form cars_UED = new Cars_UAD();
            cars_UED.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //-----------------DinamikBasliqMetni----------------------------
            int saat;
            saat = int.Parse(DateTime.Now.ToString("HH"));
            if (saat >= 6 && saat < 13)
            {
                label1.Text = "Sabahınız xeyir!".ToUpper();
            }
            else if (saat >= 13 && saat < 18)
            {
                label1.Text = "Günortanız xeyir!".ToUpper();
            }
            else if (saat >= 18 && saat < 24)
            {
                label1.Text = "Axşamınız xeyir!".ToUpper();
            }
            else
            {
                label1.Text = "Gecəniz xeyir!".ToUpper();
            }
            //-----------------CanliZaman------------------------------------
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToString("dddd , MMMM dd yyyy").ToUpper();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Services_Search = new Services_Search();
            Services_Search.ShowDialog();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Cars_Search = new Cars_Search();
            Cars_Search.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form VAS = new ViewAutoServices();
            VAS.ShowDialog();
        }
    }
}
