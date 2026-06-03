using System;

namespace MoviesApp.Models
{
    public class Movie
    {
        public int Mid { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public System.DateTime DateOfRelease { get; set; }
    }
}