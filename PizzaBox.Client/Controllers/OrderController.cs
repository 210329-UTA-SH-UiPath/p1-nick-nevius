using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly Client client = null;
        public OrderController(Client client)
        { 
            this.client = client;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Menu()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            // need to generate a list with elements that store their own ID
            var listItems = new List<Models.ListItem>();
            for (int i = 0; i < sessionOrder.Pizzas.Count; i++)
            {
                listItems.Add(new Models.ListItem() { Index = i, Item = sessionOrder.Pizzas[i] });
            }
            ViewBag.PizzaOptions = new SelectList(listItems, "Index", "Name");
            return View(sessionOrder);
        }

        [HttpGet]
        public IActionResult CheckConstraints()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            if (sessionOrder.Price > 250.0m)
            {
                sessionOrder.Pizzas.Remove(sessionOrder.Pizzas.Last());
            }

            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return RedirectToAction("Menu", "Order");
        }


        [HttpGet]
        public IActionResult CustomerOrderHistory([FromQuery] string Name)
        {
            var orders = client.GetAllOrders().Where(o => o.Customer.Name.Equals(Name));
            return View("CustomerOrderHistory", orders);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int ID)
        {
            var order = client.GetAllOrders().FirstOrDefault(o => o.ID == ID);
            if (order is null)
            {
                return BadRequest("Order does not exist");
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult Place()
        {
            // place the order by posting it to the API and praying to god it works
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            bool result = client.PostOrder(sessionOrder);
            return null;
        }

    }
}
