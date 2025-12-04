using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Movie_Database_Application.Domain;

namespace Movie_Database_Application.Forms
{
    public partial class MainForm : Form
    {
        private List<Movie> allMovies = new List<Movie>();
        private readonly string currentUser;
        private readonly bool isAdmin;
        private readonly int userId;
        private readonly bool browseAll;
        private readonly string connectionString = @"Server=Makku\SQLEXPRESS;Database=MovieDatabase;Trusted_Connection=True;";

        public MainForm(string username, bool isAdminMode, int userId, bool browseAll = false)
        {
            InitializeComponent();

            currentUser = username;
            isAdmin = isAdminMode;
            this.userId = userId;
            this.browseAll = browseAll;

            InitializeListView();
            LoadFromDatabase();
            ConfigurePermissions();
        }

        private void ConfigurePermissions()
        {
            // Non-admin users browsing the global list should not be able to add or delete
            if (!isAdmin && browseAll)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void InitializeListView()
        {
            lvMovies.View = View.Details;
            lvMovies.FullRowSelect = true;
            lvMovies.Columns.Clear();
            lvMovies.Columns.Add("Title", 200);
            lvMovies.Columns.Add("Genre", 100);
            lvMovies.Columns.Add("Year", 70);
            lvMovies.Columns.Add("Rating", 70);
            lvMovies.Columns.Add("Category", 100);
            lvMovies.Columns.Add("Added By", 120);
        }

        private void LoadFromDatabase()
        {
            allMovies.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                string query = (isAdmin || browseAll)
                    ? @"SELECT m.MovieID, m.Title, m.Genre, m.Year, m.Rating, m.Synopsis, m.Category, u.Username, m.UserID
                        FROM Movies m
                        JOIN Users u ON m.UserID = u.UserID"
                    : @"SELECT m.MovieID, m.Title, m.Genre, m.Year, m.Rating, m.Synopsis, m.Category, u.Username, m.UserID
                        FROM Movies m
                        JOIN Users u ON m.UserID = u.UserID
                        WHERE m.UserID=@userId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!isAdmin && !browseAll)
                        cmd.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allMovies.Add(new Movie
                            {
                                MovieID = Convert.ToInt32(reader["MovieID"]),
                                Title = reader["Title"].ToString(),
                                Genre = reader["Genre"].ToString(),
                                Year = reader["Year"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Year"]) : null,
                                Rating = reader["Rating"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Rating"]) : null,
                                Category = reader["Category"].ToString(),
                                Synopsis = reader["Synopsis"].ToString(),
                                Username = reader["Username"].ToString(),
                                UserID = Convert.ToInt32(reader["UserID"])
                            });
                        }
                    }
                }
            }

            allMovies = allMovies.OrderBy(m => m.Title).ToList();
            UpdateListView(allMovies);
        }

        private void UpdateListView(List<Movie> movies)
        {
            lvMovies.Items.Clear();
            foreach (var movie in movies)
            {
                var item = new ListViewItem(new[]
                {
                    movie.Title,
                    movie.Genre,
                    movie.Year?.ToString() ?? "",
                    movie.Rating?.ToString() ?? "",
                    movie.Category,
                    movie.Username
                });
                item.Tag = movie;
                lvMovies.Items.Add(item);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();
            var filtered = allMovies
                .Where(m =>
                    (m.Title?.ToLower().Contains(query) ?? false) ||
                    (m.Genre?.ToLower().Contains(query) ?? false) ||
                    m.Year?.ToString().Contains(query) == true ||
                    (m.Category?.ToLower().Contains(query) ?? false))
                .OrderBy(m => m.Title)
                .ToList();

            UpdateListView(filtered);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new MovieForm(userId, connectionString);
            form.ShowDialog();

            if (form.GetSavedMovie() != null)
                LoadFromDatabase();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0) return;
            if (lvMovies.SelectedItems[0].Tag is not Movie movie) return;

            using var form = new MovieForm(userId, connectionString, movie.MovieID);
            form.ShowDialog();

            if (form.GetSavedMovie() != null)
                LoadFromDatabase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a movie to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvMovies.SelectedItems[0].Tag is not Movie movie) return;

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this movie?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Movies WHERE MovieID=@movieId AND (UserID=@userId OR @isAdmin=1)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@movieId", movie.MovieID);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@isAdmin", isAdmin ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadFromDatabase();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0) return;
            if (lvMovies.SelectedItems[0].Tag is not Movie movie) return;

            var detailsForm = new MovieDetailsForm(movie);
            detailsForm.ShowDialog();
        }
    }
}
