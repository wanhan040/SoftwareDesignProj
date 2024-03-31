using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DashBoardDentalClinic
{
    public partial class CreateAccount : Form
    {
        private string connectionString = "Server=localhost;Database=dentaldb;User ID=root;Password=@d3adlyk0h0l;";
        private MySqlConnection connection;

        public CreateAccount()
        {
            InitializeComponent();
        }
        private void usernameTextbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void passTextbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmpassTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void acctypeTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            // Check if any required fields are empty
            if (string.IsNullOrEmpty(usernameTextbox2.Text) || string.IsNullOrEmpty(passTextbox2.Text) || string.IsNullOrEmpty(acctypeComboBox.Text))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prompt the user for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to create this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    string query = "INSERT INTO accounts_tbl (Username, Password, TypeofAccount) VALUES (@Username, @Password, @AccountType)";

                    // Create a MySqlCommand object
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@Username", usernameTextbox2.Text);
                    cmd.Parameters.AddWithValue("@Password", passTextbox2.Text);
                    cmd.Parameters.AddWithValue("@AccountType", acctypeComboBox.Text);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the query was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Clear the input fields
                        usernameTextbox2.Text = "";
                        passTextbox2.Text = "";
                        confirmpassTextbox.Text = "";
                        acctypeComboBox.SelectedIndex = -1;
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

        private void alreadyLinklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm newForm = new LoginForm();
            newForm.Show();
            this.Hide();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
