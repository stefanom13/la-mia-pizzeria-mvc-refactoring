using la_mia_pizzeria_mvc_refactoring.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_mvc_refactoring.Controllers
{
    public class PizzaController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                IQueryable<Pizza> listPizza = db.Pizze.Include(piz => piz.Categorie);
                // List<Pizza> listPizza = db.Pizzas.OrderBy(pizza => pizza.Id).ToList<Pizza>();
                if (listPizza == null)
                {
                    return NotFound("Pizze non presenti");
                }
                return View("Index", listPizza.ToList());
            }
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
