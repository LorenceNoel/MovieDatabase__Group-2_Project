namespace Movie_Database_Application.Domain
{
    public class Movie
    {
        // Added properties that are referenced throughout the application
        public int MovieID { get; set; }
        public int UserID { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        // Make Year and Rating nullable to match database nullable behavior and form code
        public int? Year { get; set; }
        public int? Rating { get; set; }
        public string Synopsis { get; set; }
        public string Category { get; set; }
        public string Username { get; set; }

        // FilePath for local movie file on user's machine
        public string FilePath { get; set; }
    }
}