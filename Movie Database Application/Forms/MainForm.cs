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

        public MainForm(string username, bool isAdminMode)
        {
            InitializeComponent();
            currentUser = username;
            isAdmin = isAdminMode;
            LoadFromCsv("movies.csv");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new MovieForm(isAdmin, currentUser);
            form.ShowDialog();
            var movie = form.GetSavedMovie(); 
            if (movie != null)
            {
                allMovies.Add(movie);
                SaveToCsv("movies.csv");
                UpdateListView(allMovies);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvMovies.SelectedItems.Count == 0) return;
            var index = lvMovies.SelectedItems[0].Index;
            var movie = allMovies[index];
            var form = new MovieForm(false, currentUser);
            form.LoadMovie(movie);
            form.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            var filtered = allMovies.Where(m =>
                m.Title.ToLower().Contains(query) ||
                m.Genre.ToLower().Contains(query) ||
                m.Year.ToString().Contains(query) ||
                m.Category.ToLower().Contains(query))
                .OrderBy(m => m.Title)
                .ToList();

            UpdateListView(filtered);
        }


        private void SaveToCsv(string path)
        {
            var lines = File.Exists(path) ? File.ReadAllLines(path).ToList() : new List<string>();
            var others = lines.Where(line => !line.EndsWith($",{currentUser}")).ToList();

            var userLines = allMovies.Select(m =>
                $"{Escape(m.Title)},{Escape(m.Genre)},{m.Year},{m.Rating},{Escape(m.Synopsis)},{Escape(m.Username)},{Escape(m.Category)}");

            File.WriteAllLines(path, others.Concat(userLines));
        }

        private void LoadFromCsv(string path)
        {
            if (!File.Exists(path)) return;

            allMovies = File.ReadAllLines(path)
                .Select(line =>
                {
                    var parts = line.Split(',');
                    if (parts.Length < 7) return null;
                    return new Movie
                    {
                        Title = parts[0],
                        Genre = parts[1],
                        Year = int.TryParse(parts[2], out int y) ? y : 0,
                        Rating = int.TryParse(parts[3], out int r) ? r : 0,
                        Synopsis = parts[4],
                        Category = parts[5],
                        Username = parts[6]
                    };
                })
                .Where(m => m != null)
                .OrderBy(m => m.Title)
                .ToList();

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
                lvMovies.Items.Add(item);
            }
        }
    }
}