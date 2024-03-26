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
    public partial class HealthRecords : Form
    {
        public HealthRecords()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 mainfoForm = new Form1();
            mainfoForm.Show();
            this.Hide();
        }

        private void HealthRecords_Load(object sender, EventArgs e)
        {

        }
    }
}
