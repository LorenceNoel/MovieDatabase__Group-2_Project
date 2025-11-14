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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lvUserMovies = new System.Windows.Forms.ListView();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(720, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5f5f2");
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 25);
            this.lblWelcome.Text = "Welcome, User!";

            this.lvUserMovies.Location = new System.Drawing.Point(30, 70);
            this.lvUserMovies.Size = new System.Drawing.Size(660, 340);
            this.lvUserMovies.View = System.Windows.Forms.View.Details;
            this.lvUserMovies.FullRowSelect = true;
            this.lvUserMovies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvUserMovies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvUserMovies.Columns.Add("Title", 200);
            this.lvUserMovies.Columns.Add("Genre", 120);
            this.lvUserMovies.Columns.Add("Year", 80);
            this.lvUserMovies.Columns.Add("Rating", 80);
            this.lvUserMovies.Columns.Add("Category", 150);

            this.btnBrowse.Location = new System.Drawing.Point(30, 430);
            this.btnBrowse.Size = new System.Drawing.Size(160, 45);
            this.btnBrowse.Text = "Browse All Movies";
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            this.btnView.Location = new System.Drawing.Point(210, 430);
            this.btnView.Size = new System.Drawing.Size(160, 45);
            this.btnView.Text = "View Details";
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnView.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            // Logout button
            this.btnLogout.Location = new System.Drawing.Point(390, 430);
            this.btnLogout.Size = new System.Drawing.Size(160, 45);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#c7533a");
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lvUserMovies);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnLogout);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}