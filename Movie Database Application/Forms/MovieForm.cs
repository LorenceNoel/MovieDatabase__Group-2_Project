using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Movie_Database_Application.Domain;

namespace Movie_Database_Application.Forms
{
    public partial class MovieForm : Form
    {
        private readonly int userId;                
        private readonly string connectionString;    
        private readonly int? movieId;              
        private Movie savedMovie;                    

        public MovieForm(int userId, string connectionString, int? movieId = null)
        {
            InitializeComponent();
            this.userId = userId;
            this.connectionString = connectionString;
            this.movieId = movieId;

            cmbGenre.Items.AddRange(new string[] {
                "Action", "Comedy", "Drama", "Sci-Fi", "Horror", "Romance", "Documentary", "Animation"
            });
            cmbGenre.SelectedIndex = 0;

            cmbCategory.Items.AddRange(new string[] {
                "Top Picks", "Watch Later", "Favorites"
            });
            cmbCategory.SelectedIndex = 0;

            if (movieId.HasValue)
                LoadMovie(movieId.Value);
        }

        public Movie GetSavedMovie() => savedMovie;

        //locates and finds the movie with the movieId and loads the saved movie details from the database
        private void LoadMovie(int movieId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Movies WHERE MovieID=@movieId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTitle.Text = reader["Title"]?.ToString() ?? string.Empty;
                            var genreVal = reader["Genre"] != DBNull.Value ? reader["Genre"].ToString() : null;
                            if (genreVal != null && cmbGenre.Items.Contains(genreVal))
                                cmbGenre.SelectedItem = genreVal;

                            txtYear.Text = reader["Year"] != DBNull.Value ? reader["Year"].ToString() : string.Empty;
                            txtRating.Text = reader["Rating"] != DBNull.Value ? reader["Rating"].ToString() : string.Empty;

                            var categoryVal = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : null;
                            if (categoryVal != null && cmbCategory.Items.Contains(categoryVal))
                                cmbCategory.SelectedItem = categoryVal;

                            txtSynopsis.Text = reader["Synopsis"]?.ToString() ?? string.Empty;
                        }
                    }
                }
            }
        }

        //saves movie as a new movie or updates movie if the movie already has an id
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string genre = cmbGenre.SelectedItem?.ToString() ?? "";
            int.TryParse(txtYear.Text.Trim(), out int year);
            int.TryParse(txtRating.Text.Trim(), out int rating);
            string category = cmbCategory.SelectedItem?.ToString() ?? "";
            string synopsis = txtSynopsis.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(genre) || year == 0 || rating == 0)
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;

                if (movieId.HasValue)
                {
                    // UPDATE existing movie
                    query = @"UPDATE Movies
                              SET Title=@title, Genre=@genre, Year=@year, Rating=@rating, Category=@category, Synopsis=@synopsis
                              WHERE MovieID=@movieId AND UserID=@userId";
                }
                else
                {
                    // INSERT new movie
                    query = @"INSERT INTO Movies (Title, Genre, Year, Rating, Category, Synopsis, UserID)
                              VALUES (@title, @genre, @year, @rating, @category, @synopsis, @userId);
                              SELECT SCOPE_IDENTITY();";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@genre", genre);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@rating", rating);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@synopsis", synopsis);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    if (movieId.HasValue)
                        cmd.Parameters.AddWithValue("@movieId", movieId.Value);

                    if (movieId.HasValue)
                    {
                        cmd.ExecuteNonQuery();
                        savedMovie = new Movie
                        {
                            MovieID = movieId.Value,
                            Title = title,
                            Genre = genre,
                            Year = year,
                            Rating = rating,
                            Category = category,
                            Synopsis = synopsis,
                            UserID = userId
                        };
                    }
                    else
                    {
                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        savedMovie = new Movie
                        {
                            MovieID = newId,
                            Title = title,
                            Genre = genre,
                            Year = year,
                            Rating = rating,
                            Category = category,
                            Synopsis = synopsis,
                            UserID = userId
                        };
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
