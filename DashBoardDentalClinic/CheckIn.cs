using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace DashBoardDentalClinic
{
    public partial class CheckIn : Form
    {
        private string connectionString = "Server=localhost;Database=dentaldb;User ID=root;Password=@d3adlyk0h0l;";
        public CheckIn()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void CheckIn_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void DisplayData()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                string query = "SELECT FirstName, Surname, PhoneNumber, MedicalHistory, Service FROM patientregistration_tbl";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Panel panel = new Panel();
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Size = new System.Drawing.Size(300, 150);

                        Label nameLabel = new Label();
                        nameLabel.Text = "Name: " + row["FirstName"].ToString() + " " + row["Surname"].ToString();
                        nameLabel.Location = new System.Drawing.Point(10, 10);
                        panel.Controls.Add(nameLabel);

                        Label phoneLabel = new Label();
                        phoneLabel.Text = "Phone: " + row["PhoneNumber"].ToString();
                        phoneLabel.Location = new System.Drawing.Point(10, 40);
                        panel.Controls.Add(phoneLabel);

                        Label historyLabel = new Label();
                        historyLabel.Text = "Medical History: " + row["MedicalHistory"].ToString();
                        historyLabel.Location = new System.Drawing.Point(10, 70);
                        panel.Controls.Add(historyLabel);

                        Label serviceLabel = new Label();
                        serviceLabel.Text = "Service: " + row["Service"].ToString();
                        serviceLabel.Location = new System.Drawing.Point(10, 100);
                        panel.Controls.Add(serviceLabel);

                        // Add panel to the form
                        dataPanel.Controls.Add(panel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 mainfoForm = new Form1();
            mainfoForm.Show();
            this.Hide();
        }

        private void dataPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgeTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}