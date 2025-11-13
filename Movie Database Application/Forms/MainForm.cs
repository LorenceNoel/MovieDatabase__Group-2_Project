using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly string csvPath;

        public MainForm(string username, bool isAdminMode)
        {
            InitializeComponent();

            currentUser = username;
            isAdmin = isAdminMode;
            csvPath = Path.Combine(Application.StartupPath, "movies.csv");

            InitializeListView();
            LoadFromCsv(csvPath);
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new MovieForm(isAdmin, currentUser);
            form.ShowDialog();
            var movie = form.GetSavedMovie();
            if (movie != null)
            {
                
                var existingMovie = allMovies.FirstOrDefault(m => m.Title == movie.Title);
                if (existingMovie != null)
                {
                    
                    int index = allMovies.IndexOf(existingMovie);
                    allMovies[index] = movie;
                }
                else
                {
                    allMovies.Add(movie);
                }

                SaveToCsv();
                UpdateListView(allMovies);
            }
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0) return;

            var item = lvMovies.SelectedItems[0];
            if (item.Tag is not Movie movie) return;

            using var form = new MovieForm(false, currentUser);
            form.LoadMovie(movie);
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            var filtered = allMovies
                .Where(m => m.Title.ToLower().Contains(query) ||
                            m.Genre.ToLower().Contains(query) ||
                            m.Year.ToString().Contains(query) ||
                            m.Category.ToLower().Contains(query))
                .OrderBy(m => m.Title)
                .ToList();

            UpdateListView(filtered);
        }

        private void SaveToCsv()
        {
            var lines = allMovies.Select(m =>
                $"{Escape(m.Title)},{Escape(m.Genre)},{m.Year},{m.Rating},{Escape(m.Synopsis)},{Escape(m.Username)},{Escape(m.Category)}");
            File.WriteAllLines(csvPath, lines);
        }

        private void LoadFromCsv(string path)
        {
            allMovies.Clear();

            if (!File.Exists(path)) return;

            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = ParseCsvLine(line);
                if (parts.Length < 7) continue;

                int.TryParse(parts[2], out int year);
                int.TryParse(parts[3], out int rating);

                var movie = new Movie
                {
                    Title = parts[0],
                    Genre = parts[1],
                    Year = year,
                    Rating = rating,
                    Synopsis = parts[4],
                    Username = parts[5],
                    Category = parts[6]
                };

                allMovies.Add(movie);
            }

            allMovies = allMovies.OrderBy(m => m.Title).ToList();
            UpdateListView(allMovies);
        }

        private string Escape(string input) => input.Contains(",") ? $"\"{input}\"" : input;

        private string[] ParseCsvLine(string line)
        {
            var parts = new List<string>();
            bool inQuotes = false;
            string current = "";

            foreach (char c in line)
            {
                if (c == '"' && !inQuotes) { inQuotes = true; continue; }
                if (c == '"' && inQuotes) { inQuotes = false; continue; }
                if (c == ',' && !inQuotes) { parts.Add(current); current = ""; continue; }
                current += c;
            }
            parts.Add(current);
            return parts.ToArray();
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
                    movie.Year.ToString(),
                    movie.Rating.ToString(),
                    movie.Category
                });
                item.Tag = movie; // store reference for safe access
                lvMovies.Items.Add(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a movie to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvMovies.SelectedItems[0];
            if (item.Tag is not Movie movie) return;

            var result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                allMovies.Remove(movie);
                SaveToCsv();
                UpdateListView(allMovies);
            }
        }
    }
}
