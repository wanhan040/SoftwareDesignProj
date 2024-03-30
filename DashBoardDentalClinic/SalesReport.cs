using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            // Set up the ProgressBar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
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

        private void SalesReport_Paint(object sender, PaintEventArgs e)
        {
            DrawCircularProgressBar(e.Graphics, progressBar1.Value, progressBar1.Minimum, progressBar1.Maximum,
                new Point(progressBar1.Location.X + progressBar1.Width / 2, progressBar1.Location.Y + progressBar1.Height / 2),
                progressBar1.Width / 2 - 5);
        }
        private void progressBar1_ValueChanged(object sender, EventArgs e)
        {
            Invalidate(); // Trigger a redraw when value changes
        }
    }
}
