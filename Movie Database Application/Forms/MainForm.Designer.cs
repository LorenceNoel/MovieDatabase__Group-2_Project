namespace Movie_Database_Application.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvMovies;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Database";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#d8d9d7");

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(100, 20);
            this.txtSearch.Size = new System.Drawing.Size(500, 27);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lvMovies
            this.lvMovies.Location = new System.Drawing.Point(20, 60);
            this.lvMovies.Size = new System.Drawing.Size(760, 400);
            this.lvMovies.View = System.Windows.Forms.View.Details;
            this.lvMovies.FullRowSelect = true;
            this.lvMovies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvMovies.Columns.Add("Title", 250);
            this.lvMovies.Columns.Add("Genre", 150);
            this.lvMovies.Columns.Add("Year", 100);
            this.lvMovies.Columns.Add("Rating", 100);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 480);
            this.btnAdd.Size = new System.Drawing.Size(120, 40);
            this.btnAdd.Text = "Add Movie";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnView
            this.btnView.Location = new System.Drawing.Point(150, 480);
            this.btnView.Size = new System.Drawing.Size(120, 40);
            this.btnView.Text = "View Details";
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnView.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(280, 480);
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "Save List";
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnLoad
            this.btnLoad.Location = new System.Drawing.Point(410, 480);
            this.btnLoad.Size = new System.Drawing.Size(120, 40);
            this.btnLoad.Text = "Load List";
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoad.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // Add controls
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvMovies);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}