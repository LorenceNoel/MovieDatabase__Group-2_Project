using System;
using System.IO;
using System.Windows.Forms;
using Movie_Database_Application.Domain;

namespace Movie_Database_Application.Forms
{
    public partial class MovieForm : Form
    {
        private readonly string username;
        private readonly bool isAdmin;

        public MovieForm(bool isAdminMode, string currentUser)
        {
            InitializeComponent();
            isAdmin = isAdminMode;
            username = currentUser;

            cmbGenre.Items.AddRange(new string[] {
                "Action", "Comedy", "Drama", "Sci-Fi", "Horror", "Romance", "Documentary", "Animation"
            });
            cmbGenre.SelectedIndex = 0;

            cmbCategory.Items.AddRange(new string[] {
                "Top Picks", "Watch Later", "Favorites"
            });
            cmbCategory.SelectedIndex = 0;
        }

        public void LoadMovie(Movie movie)
        {
            txtTitle.Text = movie.Title;
            cmbGenre.SelectedItem = movie.Genre;
            txtYear.Text = movie.Year.ToString();
            txtRating.Text = movie.Rating.ToString();
            txtSynopsis.Text = movie.Synopsis;
            cmbCategory.SelectedItem = movie.Category;
        }

        public Movie GetSavedMovie()
        {
            return new Movie
            {
                Title = txtTitle.Text.Trim(),
                Genre = cmbGenre.SelectedItem?.ToString() ?? "",
                Year = int.TryParse(txtYear.Text.Trim(), out int y) ? y : 0,
                Rating = int.TryParse(txtRating.Text.Trim(), out int r) ? r : 0,
                Synopsis = txtSynopsis.Text.Trim(),
                Category = cmbCategory.SelectedItem?.ToString() ?? "",
                Username = username
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string genre = cmbGenre.SelectedItem?.ToString() ?? "";
            string year = txtYear.Text.Trim();
            string rating = txtRating.Text.Trim();
            string synopsis = txtSynopsis.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(genre) ||
                string.IsNullOrWhiteSpace(year) ||
                string.IsNullOrWhiteSpace(rating))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newLine = $"{title},{genre},{year},{rating},{synopsis},{category},{username}";
            string moviePath = @"C:\Users\gonza\OneDrive\Documents\FALL2025\MovieDatabase__Group-2_Project\movies.csv";
            File.AppendAllText(moviePath, newLine + Environment.NewLine);
            MessageBox.Show("Movie added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}