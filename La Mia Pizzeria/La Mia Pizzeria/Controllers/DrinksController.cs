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


       

    }
}
//djhskjhfkjhfd