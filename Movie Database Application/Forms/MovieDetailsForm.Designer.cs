namespace Movie_Database_Application.Forms
{
    partial class MovieDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtSynopsis;
        private System.Windows.Forms.Button btnClose;

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
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(520, 420);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movie Details";
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5f5f2");
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            int y = 30;
            int spacing = 35;

            this.lblTitle.Location = new System.Drawing.Point(30, y);
            this.lblTitle.Size = new System.Drawing.Size(460, 25);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            y += spacing;

            this.lblGenre.Location = new System.Drawing.Point(30, y);
            this.lblGenre.Size = new System.Drawing.Size(460, 25);
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += spacing;

            this.lblYear.Location = new System.Drawing.Point(30, y);
            this.lblYear.Size = new System.Drawing.Size(460, 25);
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += spacing;

            this.lblRating.Location = new System.Drawing.Point(30, y);
            this.lblRating.Size = new System.Drawing.Size(460, 25);
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += spacing;

            this.lblCategory.Location = new System.Drawing.Point(30, y);
            this.lblCategory.Size = new System.Drawing.Size(460, 25);
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += spacing;

            this.lblUser.Location = new System.Drawing.Point(30, y);
            this.lblUser.Size = new System.Drawing.Size(460, 25);
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += spacing;

            this.txtSynopsis.Location = new System.Drawing.Point(30, y);
            this.txtSynopsis.Size = new System.Drawing.Size(460, 100);
            this.txtSynopsis.Multiline = true;
            this.txtSynopsis.ReadOnly = true;
            this.txtSynopsis.BackColor = System.Drawing.ColorTranslator.FromHtml("#faebd9");
            this.txtSynopsis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSynopsis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            y += 120;

            this.btnClose.Location = new System.Drawing.Point(200, y);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.BackColor = System.Drawing.ColorTranslator.FromHtml("#9a9360");
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.btnClose);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}