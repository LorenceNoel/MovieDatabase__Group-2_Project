using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Movie_Database_Application.Domain;

namespace Movie_Database_Application.Forms
{
    public partial class UserProfileForm : Form
    {
        private readonly string username;
        private readonly bool isAdmin;
        private readonly int userId;
        private readonly string connectionString = @"Server=Makku\SQLEXPRESS;Database=MovieDatabase;Trusted_Connection=True;";

        public UserProfileForm(string username, bool isAdmin, int userId)
        {
            InitializeComponent();
            this.username = username;
            this.isAdmin = isAdmin;
            this.userId = userId;

            lblWelcome.Text = $"Welcome, {username}!";
            InitializeListView();
            LoadUserMovies();
        }

        private void InitializeListView()
        {
            lvUserMovies.Clear();
            lvUserMovies.View = View.Details;
            lvUserMovies.FullRowSelect = true;
            lvUserMovies.GridLines = true;

            lvUserMovies.Columns.Add("Title", 200);
            lvUserMovies.Columns.Add("Genre", 100);
            lvUserMovies.Columns.Add("Year", 50);
            lvUserMovies.Columns.Add("Rating", 50);
            lvUserMovies.Columns.Add("Category", 100);
        }

        private void LoadUserMovies()
        {
            lvUserMovies.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;

                if (isAdmin)
                {
                    // Admin sees all movies
                    query = @"SELECT TOP (1000) [MovieID], [Title], [Genre], [Year], [Rating], [Synopsis], [Category], [UserID]
                              FROM [MovieDatabase].[dbo].[Movies]
                              ORDER BY Title";
                }
                else
                {
                    // Non-admin sees only their WatchLater movies
                    query = @"SELECT m.MovieID, m.Title, m.Genre, m.Year, m.Rating, m.Synopsis, m.Category, m.UserID
                              FROM [MovieDatabase].[dbo].[Movies] m
                              INNER JOIN [MovieDatabase].[dbo].[WatchLater] wl ON m.MovieID = wl.MovieID
                              WHERE wl.UserID = @userId
                              ORDER BY m.Title";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!isAdmin)
                        cmd.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int rowCount = 0;

                        while (reader.Read())
                        {
                            rowCount++;

                            var movie = new Movie
                            {
                                MovieID = reader["MovieID"] != DBNull.Value ? Convert.ToInt32(reader["MovieID"]) : 0,
                                Title = reader["Title"]?.ToString() ?? string.Empty,
                                Genre = reader["Genre"]?.ToString() ?? string.Empty,
                                Year = reader["Year"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Year"]) : null,
                                Rating = reader["Rating"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Rating"]) : null,
                                Category = reader["Category"]?.ToString() ?? string.Empty,
                                Synopsis = reader["Synopsis"]?.ToString() ?? string.Empty,
                                Username = isAdmin ? "Admin" : username
                            };

                            var item = new ListViewItem(movie.Title);
                            item.SubItems.Add(movie.Genre);
                            item.SubItems.Add(movie.Year?.ToString() ?? string.Empty);
                            item.SubItems.Add(movie.Rating?.ToString() ?? string.Empty);
                            item.SubItems.Add(movie.Category);
                            item.Tag = movie;

                            lvUserMovies.Items.Add(item);
                        }

                        if (rowCount == 0)
                            MessageBox.Show("No movies found.Add you movies to start.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var form = new MainForm(username, isAdmin, userId, browseAll: true);
            form.ShowDialog();
            LoadUserMovies();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvUserMovies.SelectedItems.Count == 0) return;
            if (lvUserMovies.SelectedItems[0].Tag is not Movie movie) return;

            var form = new MovieDetailsForm(movie);
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    var newProfile = new UserProfileForm(loginForm.Username, loginForm.IsAdmin, loginForm.UserID);
                    newProfile.ShowDialog();
                }
                else
                {
                    this.Show();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lvUserMovies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a movie to play.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvUserMovies.SelectedItems[0].Tag is not Movie movie) return;

            using var player = new MoviePlayerForm(movie.Title, movie.FilePath);
            player.ShowDialog();
        }
    }
}
