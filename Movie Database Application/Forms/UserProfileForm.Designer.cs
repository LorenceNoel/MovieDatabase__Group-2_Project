namespace Movie_Database_Application.Forms
{
    partial class UserProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ListView lvUserMovies;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPlay; // Declare the Play button

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lvUserMovies = new ListView();
            btnBrowse = new Button();
            btnView = new Button();
            btnLogout = new Button();
            btnPlay = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(217, 37);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, User!";
            // 
            // lvUserMovies
            // 
            lvUserMovies.BorderStyle = BorderStyle.FixedSingle;
            lvUserMovies.Font = new Font("Segoe UI", 10F);
            lvUserMovies.FullRowSelect = true;
            lvUserMovies.Location = new Point(30, 70);
            lvUserMovies.Name = "lvUserMovies";
            lvUserMovies.Size = new Size(660, 340);
            lvUserMovies.TabIndex = 1;
            lvUserMovies.UseCompatibleStateImageBehavior = false;
            lvUserMovies.View = View.Details;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(154, 147, 96);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(30, 430);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(160, 45);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse All Movies";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnView
            // 
            btnView.BackColor = Color.FromArgb(154, 147, 96);
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(210, 430);
            btnView.Name = "btnView";
            btnView.Size = new Size(160, 45);
            btnView.TabIndex = 3;
            btnView.Text = "View Details";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(199, 83, 58);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(530, 430);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(160, 45);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.FromArgb(76, 175, 80);
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(389, 430);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(120, 45);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play Movie";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // UserProfileForm
            // 
            BackColor = Color.FromArgb(245, 245, 242);
            ClientSize = new Size(720, 520);
            Controls.Add(lblWelcome);
            Controls.Add(lvUserMovies);
            Controls.Add(btnBrowse);
            Controls.Add(btnView);
            Controls.Add(btnLogout);
            Controls.Add(btnPlay);
            Font = new Font("Segoe UI", 10F);
            Name = "UserProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Profile";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}