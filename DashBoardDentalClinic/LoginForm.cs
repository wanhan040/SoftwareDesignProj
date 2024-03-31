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
    using MySql.Data.MySqlClient;


namespace DashBoardDentalClinic
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Server=localhost;Database=dentaldb;User ID=root;Password=@d3adlyk0h0l;";
        private MySqlConnection connection;
        private bool isPasswordHidden = true;
        public LoginForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            InitializeDatabaseConnection();
            passTextbox.PasswordChar = '*'; // Set the PasswordChar to mask characters

        }
        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = usenameTextbox.Text;
            string password = passTextbox.Text;

            // Check if either the username or password is empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method early if either field is empty
            }

            try
            {
                connection.Open();

                // Authenticate user
                if (AuthenticateUser(username, password))
                {
                    // Open the main form (replace MainForm with your actual main form)
                    Form1 mainForm = new Form1();
                    this.Hide();
                    mainForm.Show();

                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Check the username and password against the database with case sensitivity
            string query = "SELECT * FROM accounts_tbl WHERE BINARY Username = @Username AND BINARY Password = @Password";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Open a new form (Replace NewForm with the actual name of your new form)
                CreateAccount createForm = new CreateAccount();
                this.Hide();
                createForm.Show();

            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (isPasswordHidden)
            {
                // If the password is currently hidden, show it
                passTextbox.PasswordChar = '\0'; // Set PasswordChar to '\0' to show the characters
                guna2ImageButton1.Image = Properties.Resources.eyebtn; // Change the image to the visible icon
            }
            else
            {
                // If the password is currently shown, hide it
                passTextbox.PasswordChar = '*'; // Set PasswordChar back to '*' to mask the characters
                guna2ImageButton1.Image = Properties.Resources.eyebtnhide; // Change the image to the hidden icon
            }

            // Toggle the state variable
            isPasswordHidden = !isPasswordHidden;
        }
    }
}
