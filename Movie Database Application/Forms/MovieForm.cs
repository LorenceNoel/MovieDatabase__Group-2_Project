using System;
using System.Windows.Forms;
using Movie_Database_Application.Domain;

namespace Movie_Database_Application.Forms
{
    public partial class MovieForm : Form
    {
        private Movie currentMovie;
        private bool isAdmin;

        public MovieForm(bool isAdminMode = false)
        {
            InitializeComponent();
            isAdmin = isAdminMode;

            btnSave.Visible = isAdmin;
            btnCancel.Visible = isAdmin;
            txtTitle.ReadOnly = !isAdmin;
            txtGenre.ReadOnly = !isAdmin;
            txtYear.ReadOnly = !isAdmin;
            txtRating.ReadOnly = !isAdmin;
            txtSynopsis.ReadOnly = !isAdmin;
        }

        public Movie GetSavedMovie()
        {
            return currentMovie;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRating.Text, out int rating) || rating < 0 || rating > 100)
            {
                MessageBox.Show("Rating must be between 0 and 100%.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentMovie = new Movie
            {
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                Year = int.TryParse(txtYear.Text, out int year) ? year : 0,
                Rating = rating,
                Synopsis = txtSynopsis.Text
            };

            MessageBox.Show("Movie saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}