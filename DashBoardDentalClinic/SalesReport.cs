﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoardDentalClinic
{
    public partial class SalesReport : Form
    {
        private string connectionString = "Server=localhost;Database=dentaldb;User ID=root;Password=@d3adlyk0h0l;";
        private MySqlConnection connection;

        public SalesReport()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
           
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 mainfoForm = new Form1();
            mainfoForm.Show();
            this.Hide();
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
