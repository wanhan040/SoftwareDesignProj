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
using MySql.Data.MySqlClient;

namespace DashBoardDentalClinic
{
    public partial class PatientInfo : Form
    {
        private string connectionString = "Server=localhost;Database=dentaldb;User ID=root;Password=@d3adlyk0h0l;";
        private MySqlConnection connection;

        public PatientInfo()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.guna2Panel1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 mainfoForm = new Form1();
            mainfoForm.Show();
            this.Hide();
        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.guna2Panel1.Visible=true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (object item in checkedListBox1.CheckedItems)
            {
                // Add each checked item to the ListView
                listView1.Items.Add(item.ToString());
                
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.guna2Panel1.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Check if any required fields are empty
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox3.Text) || string.IsNullOrEmpty(guna2TextBox4.Text))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prompt the user for confirmation
            DialogResult result = MessageBox.Show("Is the information correct?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user confirms the action, save the account details to the database
            if (result == DialogResult.Yes)
            {
                MySqlConnection connection = null;
                try
                {
                    // Open a connection to the database
                    connection = new MySqlConnection(connectionString);
                    connection.Open();

                    // Define the query to insert the account details
                    string query = "INSERT INTO patientregistration_tbl (FirstName, Surname, PhoneNumber, MedicalHistory, Service) VALUES (@Firstname, @Surname,@PhoneNumber, @MedicalHistory, @Service)";

                    // Create a MySqlCommand object
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@Firstname", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Surname", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@MedicalHistory", guna2TextBox4.Text);

                    // Extract ListView items and concatenate them into a single string
                    StringBuilder services = new StringBuilder();
                    foreach (ListViewItem item in listView1.Items)
                    {
                        services.Append(item.Text);
                        services.Append(", "); // Add a separator between items
                    }

                    // Remove the trailing separator and set the parameter value
                    string servicesString = services.ToString().TrimEnd(',', ' ');
                    cmd.Parameters.AddWithValue("@Service", servicesString);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the query was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Clear the input fields
                        guna2TextBox1.Text = "";
                        guna2TextBox2.Text = "";
                        guna2TextBox3.Text = "";
                        guna2TextBox4.Text = "";
                        listView1.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

    }
}
