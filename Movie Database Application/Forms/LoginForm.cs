using System;
using System.IO;
using System.Windows.Forms;

namespace Movie_Database_Application.Forms
{
    public partial class LoginForm : Form
    {
        public string Username { get; private set; }
        public bool IsAdmin { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private string GetUserFilePath()
        {
            string path = Path.Combine(Application.StartupPath, "users.csv");

           
            if (!File.Exists(path))
                File.WriteAllText(path, ""); 

            return path;
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

            string userPath = GetUserFilePath();

            foreach (var line in File.ReadAllLines(userPath))
            {
                var parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    string savedUsername = parts[0].Trim();
                    string savedPassword = parts[1].Trim();
                    string savedIsAdmin = parts[2].Trim();

                    if (savedUsername == username && savedPassword == password)
                    {
                        Username = savedUsername;
                        IsAdmin = bool.TryParse(savedIsAdmin, out bool isAdmin) && isAdmin;
                        DialogResult = DialogResult.OK;
                        return;
                    }
                }
            }

            MessageBox.Show("User not found, Please register!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string userPath = GetUserFilePath();

            foreach (var line in File.ReadAllLines(userPath))
            {
                var parts = line.Split(',');
                if (parts.Length >= 1 && parts[0].Trim() == username)
                {
                    MessageBox.Show("Username already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string newUser = $"{username},{password},false";
            File.AppendAllText(userPath, newUser + Environment.NewLine);
            MessageBox.Show("Registration successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
