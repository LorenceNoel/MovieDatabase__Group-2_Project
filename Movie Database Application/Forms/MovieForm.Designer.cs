namespace Movie_Database_Application.Forms
{
    partial class MovieForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtSynopsis;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(600, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#d8d9d7");
            this.Text = "Movie Details";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTitle.Location = new System.Drawing.Point(40, 70);
            this.lblTitle.Text = "Title:";

            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTitle.Location = new System.Drawing.Point(100, 70);
            this.txtTitle.Size = new System.Drawing.Size(480, 27);
            this.txtTitle.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");

            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGenre.Location = new System.Drawing.Point(40, 110);
            this.lblGenre.Text = "Genre:";

            this.txtGenre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGenre.Location = new System.Drawing.Point(100, 110);
            this.txtGenre.Size = new System.Drawing.Size(150, 27);
            this.txtGenre.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");

            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblYear.Location = new System.Drawing.Point(270, 110);
            this.lblYear.Text = "Year:";

            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtYear.Location = new System.Drawing.Point(320, 110);
            this.txtYear.Size = new System.Drawing.Size(80, 27);
            this.txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");

            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRating.Location = new System.Drawing.Point(420, 110);
            this.lblRating.Text = "Rating (%):";

            this.txtRating.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRating.Location = new System.Drawing.Point(510, 110);
            this.txtRating.Size = new System.Drawing.Size(70, 27);
            this.txtRating.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");

            this.lblSynopsis.AutoSize = true;
            this.lblSynopsis.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSynopsis.Location = new System.Drawing.Point(40, 160);
            this.lblSynopsis.Text = "Synopsis:";

            this.txtSynopsis.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSynopsis.Location = new System.Drawing.Point(40, 190);
            this.txtSynopsis.Multiline = true;
            this.txtSynopsis.Size = new System.Drawing.Size(540, 180);
            this.txtSynopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSynopsis.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");

            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(400, 400);
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.Text = "Save";
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(490, 400);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

