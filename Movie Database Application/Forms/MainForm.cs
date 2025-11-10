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
        private bool isAdmin;

        public MainForm(bool isAdminMode = false)
        {
            InitializeComponent();
            isAdmin = isAdminMode;
            UpdateListView(allMovies);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new MovieForm(isAdmin);
            form.ShowDialog();
            var movie = form.GetSavedMovie();
            if (movie != null)
            {
                allMovies.Add(movie);
                UpdateListView(allMovies);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0) return;
            var index = lvMovies.SelectedItems[0].Index;
            var movie = allMovies[index];
            var form = new MovieForm(false);
            form.LoadMovie(movie);
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            var filtered = allMovies.Where(m =>
                m.Title.ToLower().Contains(query) ||
                m.Genre.ToLower().Contains(query) ||
                m.Year.ToString().Contains(query)).ToList();

            UpdateListView(filtered);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveToCsv("movies.csv");
            MessageBox.Show("List saved to movies.csv");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFromCsv("movies.csv");
        }

        private void SaveToCsv(string path)
        {
            var lines = allMovies.Select(m =>
                $"{Escape(m.Title)},{Escape(m.Genre)},{m.Year},{m.Rating},{Escape(m.Synopsis)}");
            File.WriteAllLines(path, lines);
        }

        private void LoadFromCsv(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("CSV file not found.");
                return;
            }

            var lines = File.ReadAllLines(path);
            allMovies = lines.Select(line =>
            {
                var parts = ParseCsvLine(line);
                return new Movie
                {
                    Title = parts[0],
                    Genre = parts[1],
                    Year = int.TryParse(parts[2], out int y) ? y : 0,
                    Rating = int.TryParse(parts[3], out int r) ? r : 0,
                    Synopsis = parts[4]
                };
            }).ToList();

            UpdateListView(allMovies);
        }

        private string Escape(string input)
        {
            return input.Contains(",") ? $"\"{input}\"" : input;
        }

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
                var item = new ListViewItem(new[] {
                    movie.Title,
                    movie.Genre,
                    movie.Year.ToString(),
                    movie.Rating.ToString()
                });
                lvMovies.Items.Add(item);
            }
        }
    }
}