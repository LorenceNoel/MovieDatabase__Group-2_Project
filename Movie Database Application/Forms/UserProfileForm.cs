using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Movie_Database_Application.Domain;
using System.Linq;

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
            LoadUserMovies();
        }

        private void LoadUserMovies()
        {
            lvUserMovies.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT MovieID, Title, Genre, Year, Rating, Category, Synopsis
                                 FROM Movies
                                 WHERE UserID = @userId
                                 ORDER BY Title";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var movie = new Movie
                            {
                                MovieID = reader["MovieID"] != DBNull.Value ? Convert.ToInt32(reader["MovieID"]) : 0,
                                Title = reader["Title"]?.ToString() ?? string.Empty,
                                Genre = reader["Genre"]?.ToString() ?? string.Empty,
                                Year = reader["Year"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Year"]) : null,
                                Rating = reader["Rating"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Rating"]) : null,
                                Category = reader["Category"]?.ToString() ?? string.Empty,
                                Synopsis = reader["Synopsis"]?.ToString() ?? string.Empty,
                                Username = username,
                                UserID = userId
                            };

                            var item = new ListViewItem(movie.Title);
                            item.SubItems.Add(movie.Genre);
                            item.SubItems.Add(movie.Year?.ToString() ?? string.Empty);
                            item.SubItems.Add(movie.Rating?.ToString() ?? string.Empty);
                            item.SubItems.Add(movie.Category);
                            item.Tag = movie;
                            lvUserMovies.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var form = new MainForm(username, isAdmin, userId);
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
            // Hide current profile while showing login
            this.Hide();
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Open a new UserProfileForm with the new credentials
                    var newProfile = new UserProfileForm(loginForm.Username, loginForm.IsAdmin, loginForm.UserID);
                    newProfile.Show();
                    // Close the current instance
                    this.Close();
                }
                else
                {
                    // If user cancelled login, close the application
                    this.Close();
                }
            }
        }

    }
}