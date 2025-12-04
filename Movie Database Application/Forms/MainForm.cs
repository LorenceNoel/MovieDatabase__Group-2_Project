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

            // Hide the Add and Delete buttons for non-admin users so they can only browse movies
            btnAdd.Visible = isAdmin;
            btnDelete.Visible = isAdmin;

            // Show Watch Later button only for non-admin users
            btnWatchLater.Visible = !isAdmin;

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

            try
            {
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
                            WHERE m.UserID = @userId
                            UNION
                            SELECT m.MovieID, m.Title, m.Genre, m.Year, m.Rating, m.Synopsis, m.Category, u.Username, wl.UserID
                            FROM WatchLater wl
                            JOIN Movies m ON wl.MovieID = m.MovieID
                            JOIN Users u ON m.UserID = u.UserID
                            WHERE wl.UserID = @userId";

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
                                    Title = reader["Title"]?.ToString() ?? string.Empty,
                                    Genre = reader["Genre"]?.ToString() ?? string.Empty,
                                    Year = reader["Year"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Year"]) : null,
                                    Rating = reader["Rating"] != DBNull.Value ? (int?)Convert.ToInt32(reader["Rating"]) : null,
                                    Category = reader["Category"]?.ToString() ?? string.Empty,
                                    Synopsis = reader["Synopsis"]?.ToString() ?? string.Empty,
                                    Username = reader["Username"]?.ToString() ?? string.Empty,
                                    UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0
                                });
                            }
                        }
                    }
                }

                allMovies = allMovies.OrderBy(m => m.Title).ToList();
                UpdateListView(allMovies);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while loading movies: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (!isAdmin)
            {
                MessageBox.Show("Only admins can add movies.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new MovieForm(userId, connectionString);
            form.ShowDialog();

            if (form.GetSavedMovie() != null)
                LoadFromDatabase();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a movie to play.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvMovies.SelectedItems[0].Tag is not Movie movie) return;

            using var player = new MoviePlayerForm(movie.Title, movie.FilePath);
            player.ShowDialog();
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
            if (!isAdmin)
            {
                MessageBox.Show("Only admins can delete movies.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvMovies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a movie to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvMovies.SelectedItems[0].Tag is not Movie movie)
            {
                MessageBox.Show("Invalid movie selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this movie?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Delete related records in WatchLater table
                    string deleteWatchLaterQuery = "DELETE FROM WatchLater WHERE MovieID=@movieId";
                    using (SqlCommand cmd = new SqlCommand(deleteWatchLaterQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@movieId", movie.MovieID);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete the movie from Movies table
                    string deleteMovieQuery = "DELETE FROM Movies WHERE MovieID=@movieId";
                    using (SqlCommand cmd = new SqlCommand(deleteMovieQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@movieId", movie.MovieID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Movie deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFromDatabase();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while deleting the movie: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0) return;
            if (lvMovies.SelectedItems[0].Tag is not Movie movie) return;

            var detailsForm = new MovieDetailsForm(movie);
            detailsForm.ShowDialog();
        }

        private void btnWatchLater_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a movie to add to Watch Later.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvMovies.SelectedItems[0].Tag is not Movie movie)
            {
                MessageBox.Show("Invalid movie selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if the movie is already in the Watch Later list
                string checkQuery = @"SELECT COUNT(*) FROM dbo.WatchLater WHERE UserID = @userId AND MovieID = @movieId";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    checkCmd.Parameters.AddWithValue("@movieId", movie.MovieID);

                    int count = 0;
                    object result = checkCmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out count) && count > 0)
                    {
                        MessageBox.Show("This movie is already in your Watch Later list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Insert the movie into the Watch Later list
                string insertQuery = @"INSERT INTO dbo.WatchLater (UserID, MovieID, AddedDate) VALUES (@userId, @movieId, @dateAdded);";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@userId", userId);
                    insertCmd.Parameters.AddWithValue("@movieId", movie.MovieID);
                    insertCmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);

                    try
                    {
                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("Movie added to Watch Later successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred while adding the movie to Watch Later: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
