using System;
using System.IO;
using System.Windows.Forms;
using Movie_Database_Application.Domain;

namespace Movie_Database_Application.Forms
{
    public partial class UserProfileForm : Form
    {
        private readonly string username;
        private readonly bool isAdmin;

        public UserProfileForm(string username, bool isAdmin)
        {
            InitializeComponent();
            this.username = username;
            this.isAdmin = isAdmin;
            lblWelcome.Text = $"Welcome, {username}!";
            LoadUserMovies();
        }

        private void LoadUserMovies()
        {
            lvUserMovies.Items.Clear();
            if (!File.Exists("movies.csv")) return;

            var lines = File.ReadAllLines("movies.csv")
                .Select(line => line.Split(','))
                .Where(parts => parts.Length >= 7 && parts[6] == username)
                .OrderBy(parts => parts[0]);

            foreach (var parts in lines)
            {
                var item = new ListViewItem(parts[0]); 
                item.SubItems.Add(parts[1]); 
                item.SubItems.Add(parts[2]); 
                item.SubItems.Add(parts[3]);
                item.SubItems.Add(parts[5]); 
                lvUserMovies.Items.Add(item);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var form = new MainForm(username, isAdmin);
            form.ShowDialog();
            LoadUserMovies();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lvUserMovies.SelectedItems.Count == 0) return;
            var selected = lvUserMovies.SelectedItems[0];
            var movie = new Movie
            {
                Title = selected.Text,
                Genre = selected.SubItems[1].Text,
                Year = int.TryParse(selected.SubItems[2].Text, out int y) ? y : 0,
                Rating = int.TryParse(selected.SubItems[3].Text, out int r) ? r : 0,
                Category = selected.SubItems[4].Text,
                Synopsis = "", 
                Username = username 
            };

            var form = new MovieForm(false, username); 
            form.LoadMovie(movie);
            form.ShowDialog();
        }

    }
}