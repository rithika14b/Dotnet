using System.Web.Mvc;
using MoviesApp.Models;
using MoviesApp.Repositories;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();

 
        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }

     
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

      
        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);

            if (movie != null)
            {
                repo.Delete(id);
                repo.Save();
            }

            return RedirectToAction("Index");
        }

        
        public ActionResult ByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View("Index", movies);
        }

        
        public ActionResult ByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            return View("Index", movies);
        }
    }
}