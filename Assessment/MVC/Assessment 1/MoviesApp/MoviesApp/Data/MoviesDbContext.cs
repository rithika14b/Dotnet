using System.Data.Entity;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}