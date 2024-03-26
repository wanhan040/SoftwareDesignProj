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
    public partial class CheckIn : Form
    {
        public CheckIn()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void CheckIn_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 mainfoForm = new Form1();
            mainfoForm.Show();
            this.Hide();
        }
    }
}
