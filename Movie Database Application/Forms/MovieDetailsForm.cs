using Movie_Database_Application.Domain;

namespace Movie_Database_Application.Forms
{
    public partial class MovieDetailsForm : Form
    {
        private readonly Movie movie;

        public MovieDetailsForm(Movie m)
        {
            InitializeComponent();
            movie = m;
            LoadMovieDetails();
        }

        private void LoadMovieDetails()
        {
            lblTitle.Text = $"Title: {movie.Title}";
            lblGenre.Text = $"Genre: {movie.Genre}";
            lblYear.Text = $"Year: {movie.Year}";
            lblRating.Text = $"Rating: {movie.Rating}";
            lblCategory.Text = $"Category: {movie.Category}";
            lblUser.Text = $"Added by: {movie.Username}";
            txtSynopsis.Text = movie.Synopsis;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}