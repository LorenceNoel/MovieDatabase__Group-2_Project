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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lvMovies = new System.Windows.Forms.ListView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Movies";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5f5f2");
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(30, 30);
            this.lblSearch.Text = "Search:";

            this.txtSearch.Location = new System.Drawing.Point(120, 28);
            this.txtSearch.Size = new System.Drawing.Size(600, 32);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lvMovies.Location = new System.Drawing.Point(30, 80);
            this.lvMovies.Size = new System.Drawing.Size(840, 400);
            this.lvMovies.View = System.Windows.Forms.View.Details;
            this.lvMovies.FullRowSelect = true;
            this.lvMovies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvMovies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvMovies.Columns.Add("Title", 250);
            this.lvMovies.Columns.Add("Genre", 150);
            this.lvMovies.Columns.Add("Year", 100);
            this.lvMovies.Columns.Add("Rating", 100);
            this.lvMovies.Columns.Add("Category", 200);

            this.btnAdd.Location = new System.Drawing.Point(30, 500);
            this.btnAdd.Size = new System.Drawing.Size(180, 45);
            this.btnAdd.Text = "➕ Add Movie";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnView.Location = new System.Drawing.Point(230, 500);
            this.btnView.Size = new System.Drawing.Size(180, 45);
            this.btnView.Text = "👁️ View Details";
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnView.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvMovies);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}