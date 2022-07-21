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
            using (PizzaContext db = new PizzaContext())
            {
                //Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
                Pizza pizza = db.Pizze.Where(pizza => pizza.Id == id).Include(cat => cat.Categorie).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound("Pizza non trovata");
                }
                else
                {
                    return View("Details", pizza);
                }
            }
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Categoria> categoria = db.Categorie.ToList();
                PizzaCategorie model = new PizzaCategorie();

                model.Categorie = categoria;
                model.Pizza = new Pizza();
                return View(model);
            }
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaCategorie p)
        {
            using (PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    p.Categorie = db.Categorie.ToList();
                    return View("Create", p);
                }

                db.Pizze.Add(p.Pizza);
                db.SaveChanges();

            }


            return RedirectToAction("Index");
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaEdit = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaEdit == null)
                {
                    return NotFound();
                }
                else
                {
                    PizzaCategorie model = new PizzaCategorie();

                    model.Pizza = pizzaEdit;
                    model.Categorie = db.Categorie.ToList();

                    return View(model);
                }
            }
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzaCategorie p)
        {
            using (PizzaContext db = new PizzaContext())
            {
                if (!ModelState.IsValid)
                {
                    p.Categorie = db.Categorie.ToList();
                    return View("Edit", p);
                }

                Pizza pizzaEdit = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();


                if (pizzaEdit != null)
                {
                    pizzaEdit.NomePizza = p.Pizza.NomePizza;
                    pizzaEdit.Descrizione = p.Pizza.Descrizione;
                    pizzaEdit.PathImage = p.Pizza.PathImage;
                    pizzaEdit.Prezzo = p.Pizza.Prezzo;
                    pizzaEdit.CategoriaId = p.Pizza.CategoriaId;

                    db.SaveChanges();
                }
                else
                {
                    return NotFound(View("Error"));
                }
            }
            return RedirectToAction("Index");
        }

        // GET: HomeController1/Delete/5
      
        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaDelete = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDelete == null)
                {

                    return NotFound();
                }
                else
                {
                    db.Pizze.Remove(pizzaDelete);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
