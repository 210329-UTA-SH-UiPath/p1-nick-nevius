using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Controllers
{
    public class PizzaController : Controller
    {

        private readonly Client client = null;

        public PizzaController(Client client)
        {
            this.client = client;
        }

        // GET: Pizza
        public ActionResult Index()
        {
            var pizzas = client.GetAllPizzas();

            return View(pizzas);
        }


        [HttpGet]
        public IActionResult Remove(int Index)
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            if (Index < 0 || Index >= sessionOrder.Pizzas.Count)
            {
                return BadRequest("Can't remove a pizza outside of order's bounds");
            }
            sessionOrder.Pizzas.RemoveAt(Index);

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return RedirectToAction("Menu", "Order");
        }

        public IActionResult SelectType()
        {
            // gets 1 Pizza of each Type
            var pizzaTypes = client.GetPizzaTypes();
            ViewBag.PizzaTypes = new SelectList(pizzaTypes, "PizzaType", "Name");

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            sessionOrder.Pizzas.Add(new Models.Pizza());

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return View(new Models.OrderItem());
        }

        [HttpPost]
        public IActionResult TypeSelected(Models.OrderItem ai)
        {
            var dbPizza = client.GetAllPizzas().FirstOrDefault(p => p.PizzaType == ai.PizzaType);
            if (dbPizza is null)
            {
                return BadRequest("Somehow you picked a Type of Pizza that doesn't exist in the DB");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            // just copy over the entire pizza
            // this ensures we have at the bare minimum a basic, working pizza
            var lastPizza = sessionOrder.Pizzas.Last();
            lastPizza.Name = dbPizza.Name;
            lastPizza.PizzaType = dbPizza.PizzaType;

            lastPizza.Crust = dbPizza.Crust;
            lastPizza.Size = dbPizza.Size;
            lastPizza.Toppings = dbPizza.Toppings;

            if (lastPizza.PizzaType == Models.PIZZA_TYPE.Custom)
            {
                // make sure we start off with no toppings
                lastPizza.Toppings.Clear();
            }

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return RedirectToAction("SelectSize", "Pizza");
        }

        [HttpGet]
        public IActionResult SelectSize()
        {
            // generate list of possible sizes
            var sizeTypes = client.GetSizeTypes();
            ViewBag.SizeTypes = new SelectList(sizeTypes, "SizeType", "Name");

            return View("SelectSize", new Models.OrderItem() { });

        }


        [HttpPost]
        public IActionResult SizeSelected(Models.OrderItem selection)
        {
            var dbSize = client.GetAllSizes().FirstOrDefault(s => s.SizeType == selection.SizeType);
            if (dbSize is null)
            {
                return BadRequest("Somehow you got a null crust?");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            var addedPizza = sessionOrder.Pizzas.Last();

            addedPizza.Size = dbSize;

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            if (addedPizza.PizzaType != Models.PIZZA_TYPE.Custom)
            {
                return RedirectToAction("CheckConstraints", "Order");
            }
            else
            {
                return RedirectToAction("Menu", "Pizza");
            }
        }


        [HttpGet]
        public IActionResult SelectCrust()
        {
            // generate list of possible sizes
            var crustTypes = client.GetCrustTypes();
            ViewBag.CrustTypes = new SelectList(crustTypes, "CrustType", "Name");
            return View("SelectCrust", new Models.OrderItem() { });
        }

        [HttpPost]
        public IActionResult CrustSelected(Models.OrderItem selection)
        {
            var dbCrust = client.GetAllCrusts().FirstOrDefault(s => s.CrustType == selection.CrustType);
            if (dbCrust is null)
            {
                return BadRequest("Somehow you got a null crust?");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var addedPizza = sessionOrder.Pizzas.Last();

            addedPizza.Crust = dbCrust;

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return RedirectToAction("Menu", "Pizza");
        }

        [HttpGet]
        public IActionResult SelectTopping()
        {
            // generate list of possible sizes
            var toppingTypes = client.GetToppingTypes();
            ViewBag.ToppingTypes = new SelectList(toppingTypes, "ToppingType", "Name");
            return View("SelectTopping", new Models.OrderItem() { });
        }


        [HttpPost]
        public IActionResult ToppingSelected(Models.OrderItem ai)
        {
            var dbTopping = client.GetAllToppings().FirstOrDefault(s => s.ToppingType == ai.ToppingType);
            if (dbTopping is null)
            {
                return BadRequest("Somehow you got a null topping?");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            var addedPizza = sessionOrder.Pizzas.Last();

            addedPizza.Toppings.Add(dbTopping);

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return RedirectToAction("Menu", "Pizza");
        }



        public IActionResult RemoveTopping(int Index)
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var lastPizza = sessionOrder.Pizzas.Last();
            if (Index < 0 || Index >= lastPizza.Toppings.Count)
            {
                return BadRequest("Tried to remove a topping that wasn't even on the pizza");
            }
            lastPizza.Toppings.RemoveAt(Index);

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return RedirectToAction("Menu", "Pizza");
        }

        public IActionResult Menu()
        {            
            return View(Utils.GetCurrentOrder(HttpContext.Session).Pizzas.Last());
        }


    }
}
