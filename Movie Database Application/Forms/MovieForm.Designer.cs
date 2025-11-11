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
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtSynopsis;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSave;

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
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(520, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movie Details";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5f5f2");
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            int labelX = 30;
            int inputX = 130;
            int y = 30;
            int spacing = 40;

            this.lblTitle.Text = "Title:";
            this.lblTitle.Location = new System.Drawing.Point(labelX, y);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            y += spacing;

            this.lblGenre.Text = "Genre:";
            this.lblGenre.Location = new System.Drawing.Point(labelX, y);
            this.lblGenre.AutoSize = true;
            y += spacing;

            this.lblYear.Text = "Year:";
            this.lblYear.Location = new System.Drawing.Point(labelX, y);
            this.lblYear.AutoSize = true;
            y += spacing;

            this.lblRating.Text = "Rating:";
            this.lblRating.Location = new System.Drawing.Point(labelX, y);
            this.lblRating.AutoSize = true;
            y += spacing;

            this.lblSynopsis.Text = "Synopsis:";
            this.lblSynopsis.Location = new System.Drawing.Point(labelX, y);
            this.lblSynopsis.AutoSize = true;
            y += spacing;

            this.lblCategory.Text = "Category:";
            this.lblCategory.Location = new System.Drawing.Point(labelX, y + 120);
            this.lblCategory.AutoSize = true;

            y = 30;
            this.txtTitle.Location = new System.Drawing.Point(inputX, y);
            this.txtTitle.Size = new System.Drawing.Size(330, 27);
            this.txtTitle.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            y += spacing;

            this.cmbGenre.Location = new System.Drawing.Point(inputX, y);
            this.cmbGenre.Size = new System.Drawing.Size(330, 27);
            this.cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGenre.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.cmbGenre.FlatStyle = FlatStyle.Flat;
            this.cmbGenre.Items.AddRange(new[] {
                "Action", "Adventure", "Animation", "Comedy", "Crime",
                "Documentary", "Drama", "Fantasy", "Historical", "Horror",
                "Musical", "Mystery", "Romance", "Sci-Fi", "Thriller", "Western"
            });
            this.cmbGenre.SelectedIndex = 0;
            y += spacing;

            this.txtYear.Location = new System.Drawing.Point(inputX, y);
            this.txtYear.Size = new System.Drawing.Size(100, 27);
            this.txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            y += spacing;

            this.txtRating.Location = new System.Drawing.Point(inputX, y);
            this.txtRating.Size = new System.Drawing.Size(100, 27);
            this.txtRating.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtRating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            y += spacing;

            this.txtSynopsis.Location = new System.Drawing.Point(inputX, y);
            this.txtSynopsis.Size = new System.Drawing.Size(330, 110);
            this.txtSynopsis.Multiline = true;
            this.txtSynopsis.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtSynopsis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.cmbCategory.Location = new System.Drawing.Point(inputX, y + 120);
            this.cmbCategory.Size = new System.Drawing.Size(200, 27);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.cmbCategory.FlatStyle = FlatStyle.Flat;
            this.cmbCategory.Items.AddRange(new[] {
                "Top Picks", "Watch Later", "Favorites", "Hidden Gems"
            });
            this.cmbCategory.SelectedIndex = 0;

            this.btnSave.Location = new System.Drawing.Point(inputX, y + 180);
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "Save";
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnSave);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}