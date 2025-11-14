using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Movie_Database_Application.Forms
{
    public partial class LoginForm : Form
    {
        public string Username { get; private set; }
        public bool IsAdmin { get; private set; }
        public int UserID { get; private set; }

        private string connectionString = @"Server=Makku\SQLEXPRESS;Database=MovieDatabase;Trusted_Connection=True;";


        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, Username, Password, IsAdmin FROM Users WHERE Username=@username AND Password=@password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserID = Convert.ToInt32(reader["UserID"]);
                            Username = reader["Username"].ToString();
                            IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                            DialogResult = DialogResult.OK;
                            return;
                        }
                    }
                }
            }

            MessageBox.Show("User not found, please register!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@username";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string insertQuery = "INSERT INTO Users (Username, Password, IsAdmin) VALUES (@username, @password, 0)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Registration successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
