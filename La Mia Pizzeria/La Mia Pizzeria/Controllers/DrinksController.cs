using La_Mia_Pizzeria.Database;
using La_Mia_Pizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace La_Mia_Pizzeria.Controllers
{
    public class DrinksController : Controller
    {
      public IActionResult Index()
        {

            using(PizzaContext dbs = new PizzaContext())
            {
                List<DrinksModel> ourDrinks = dbs.Bevande.ToList();
                return View(ourDrinks);
            }
        }


        [HttpGet]
        public IActionResult Create() {
        
        return View();
        
        }



        [HttpPost]
        public IActionResult Create(DrinksModel newDrinks)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", newDrinks);
            }
            using(PizzaContext dbs = new PizzaContext())
            {
                dbs.Bevande.Add(newDrinks);
                dbs.SaveChanges();
                return RedirectToAction("Index");   
            }
        }





    }
}
//djhskjhfkjhfd