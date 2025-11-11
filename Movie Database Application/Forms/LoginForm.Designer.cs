namespace Movie_Database_Application.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(420, 380);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5f5f2");
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(60, 30);
            this.lblTitle.Size = new System.Drawing.Size(300, 45);
            this.lblTitle.Text = "Welcome!";

            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 100);
            this.lblUsername.Text = "Username:";

            this.txtUsername.Location = new System.Drawing.Point(40, 125);
            this.txtUsername.Size = new System.Drawing.Size(340, 30);
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;

            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 170);
            this.lblPassword.Text = "Password:";

            this.txtPassword.Location = new System.Drawing.Point(40, 195);
            this.txtPassword.Size = new System.Drawing.Size(340, 30);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;

            this.btnLogin.Location = new System.Drawing.Point(40, 250);
            this.btnLogin.Size = new System.Drawing.Size(340, 40);
            this.btnLogin.Text = "Login";
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.btnRegister.Location = new System.Drawing.Point(40, 300);
            this.btnRegister.Size = new System.Drawing.Size(340, 40);
            this.btnRegister.Text = "Register";
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnRegister.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}