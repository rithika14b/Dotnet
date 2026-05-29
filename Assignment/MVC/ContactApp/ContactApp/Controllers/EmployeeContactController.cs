using System.Threading.Tasks;
using System.Web.Mvc;
using MvcAsyncDemo.Models;
using MvcAsyncDemo.Repositories;

namespace MvcAsyncDemo.Controllers
{
    public class EmployeeContactController : Controller
    {
        private readonly IEmployeeContactRepository repository;

        public EmployeeContactController()
        {
            repository = new EmployeeContactRepository();
        }

        public async Task<ActionResult> Index()
        {
            var result = await repository.GetAllAsync();

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmployeeContact employee)
        {
            if (ModelState.IsValid)
            {
                await repository.AddAsync(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await repository.RemoveAsync(id);

            return RedirectToAction("Index");
        }
    }
}