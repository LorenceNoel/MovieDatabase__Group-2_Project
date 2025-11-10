using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Movie_Database_Application.Forms
{
    public partial class LoginForm : Form
    {
        public bool IsAdmin { get; private set; }

        private readonly string userFile = "users.csv";

        public LoginForm()
        {
            InitializeComponent();
            if (!File.Exists(userFile))
                File.WriteAllText(userFile, "admin,admin,true\n"); // default admin
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var lines = File.ReadAllLines(userFile);
            var match = lines.FirstOrDefault(line =>
            {
                var parts = line.Split(',');
                return parts[0] == username && parts[1] == password;
            });

            if (match != null)
            {
                IsAdmin = match.Split(',')[2].ToLower() == "true";
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lines = File.ReadAllLines(userFile);
            if (lines.Any(line => line.Split(',')[0] == username))
            {
                MessageBox.Show("Username already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            File.AppendAllText(userFile, $"{username},{password},false\n");
            MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}