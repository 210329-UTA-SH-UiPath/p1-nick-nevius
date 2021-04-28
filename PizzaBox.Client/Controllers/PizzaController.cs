using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]
        public IActionResult SelectPizzaType(Models.Order order)
        {


            

            var orders = client.GetAllOrders().Where(o => o.Customer.Name.Equals(order.Customer.Name));
            return View("CustomerOrderHistory", orders);
        }
    }
}
