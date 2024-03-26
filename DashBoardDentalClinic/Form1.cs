using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoardDentalClinic
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm newForm = new LoginForm();
            newForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            PatientInfo patientinfoForm = new PatientInfo();
            patientinfoForm.Show();
            this.Hide();

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            CheckIn checkinForm = new CheckIn();
            checkinForm.Show();
            this.Hide();
        }


        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Queue queueForm = new Queue();
            queueForm.Show();
            this.Hide();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            HealthRecords healthRecordsForm = new HealthRecords();
            healthRecordsForm.Show();
            this.Hide();
        }

        private void salesButton_Click_1(object sender, EventArgs e)
        {
            SalesReport salesReport = new SalesReport();
            salesReport.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
