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

        [HttpGet]

        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                DrinksModel? drinksToModify = db.Bevande.Where(DrinksModel => DrinksModel.Id == id).FirstOrDefault();
                if (drinksToModify != null)
                {

                    return View("Update", drinksToModify);

                }
                else
                {
                    return NotFound($"la bevanda con id {id} non è stato trovato!");


                }


            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, DrinksModel newDrinks)
        {
            if (ModelState.IsValid)
            {
                return View("Update", newDrinks);
            }

            using (PizzaContext db = new PizzaContext())
            {
                DrinksModel? DrinksToModify = db.Bevande.Where(DrinksModel => DrinksModel.Id == id).FirstOrDefault();

                if (DrinksToModify != null)
                {
                    DrinksToModify.Name = newDrinks.Name;
                    DrinksToModify.Description = newDrinks.Description; 
                    DrinksToModify.ImgSource = newDrinks.ImgSource;
                    DrinksToModify.Price = newDrinks.Price;
                    DrinksToModify.Liters = newDrinks.Liters;
                 

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound(" La bottiglia da modificare non esiste!");
                }


            }

        }

    }
}
//djhskjhfkjhfd