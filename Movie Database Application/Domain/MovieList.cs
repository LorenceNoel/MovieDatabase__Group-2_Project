using System.Collections.Generic;

namespace Movie_Database_Application.Domain
{
    public class MovieList
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}