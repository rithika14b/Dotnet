using MoviesApp.Data;
using MoviesApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesDbContext db = new MoviesDbContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
                db.Movies.Remove(movie);
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            return db.Movies.Where(m => m.DateOfRelease.Year == year).ToList();
        }

        public IEnumerable<Movie> GetByDirector(string directorName)
        {
            return db.Movies.Where(m => m.DirectorName == directorName).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}