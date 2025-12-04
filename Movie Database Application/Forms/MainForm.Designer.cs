namespace Movie_Database_Application.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvMovies;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnWatchLater; // Declare the Watch Later button

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lvMovies = new ListView();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnView = new Button();
            lblSearch = new Label();
            btnDelete = new Button();
            btnPlay = new Button();
            btnWatchLater = new Button();
            SuspendLayout();
            // 
            // lvMovies
            // 
            lvMovies.BorderStyle = BorderStyle.FixedSingle;
            lvMovies.Font = new Font("Segoe UI", 10F);
            lvMovies.FullRowSelect = true;
            lvMovies.Location = new Point(30, 80);
            lvMovies.Name = "lvMovies";
            lvMovies.Size = new Size(840, 400);
            lvMovies.TabIndex = 2;
            lvMovies.UseCompatibleStateImageBehavior = false;
            lvMovies.View = View.Details;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(250, 235, 217);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(120, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(600, 32);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(154, 147, 96);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(30, 500);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 45);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "➕ Add Movie";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnView
            // 
            btnView.BackColor = Color.FromArgb(154, 147, 96);
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(180, 500);
            btnView.Name = "btnView";
            btnView.Size = new Size(140, 45);
            btnView.TabIndex = 4;
            btnView.Text = "👁️ View Details";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.FromArgb(70, 130, 180);
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(330, 500);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(140, 45);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "▶️ Play";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSearch.Location = new Point(30, 30);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(80, 28);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(154, 147, 96);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(630, 500);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 45);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnWatchLater
            // 
            btnWatchLater.BackColor = Color.FromArgb(154, 147, 96);
            btnWatchLater.FlatStyle = FlatStyle.Flat;
            btnWatchLater.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnWatchLater.ForeColor = Color.White;
            btnWatchLater.Location = new Point(480, 500);
            btnWatchLater.Name = "btnWatchLater";
            btnWatchLater.Size = new Size(140, 45);
            btnWatchLater.TabIndex = 7;
            btnWatchLater.Text = "⭐ Watch Later";
            btnWatchLater.UseVisualStyleBackColor = false;
            btnWatchLater.Click += btnWatchLater_Click;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(245, 245, 242);
            ClientSize = new Size(900, 600);
            Controls.Add(btnWatchLater);
            Controls.Add(btnDelete);
            Controls.Add(btnPlay);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(lvMovies);
            Controls.Add(btnAdd);
            Controls.Add(btnView);
            Font = new Font("Segoe UI", 10F);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Movies";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}