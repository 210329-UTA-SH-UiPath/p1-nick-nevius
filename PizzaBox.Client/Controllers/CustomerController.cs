using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Client client = null;

        public CustomerController(Client client)
        {
            this.client = client;
        }

        public IActionResult Index()
        {
            // let them select a customer
            return View(new Models.Customer());
        }
        
        [HttpPost]
        public IActionResult SelectedCustomer(Models.Customer customer)
        {
            if (customer is null)
            {
                return BadRequest("Customer was null somehow");
            }
            var customers = client.GetAllCustomers();
            var foundCustomer = customers.FirstOrDefault(c => c.Name.Equals(customer.Name));

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            if (foundCustomer is not null)
            {
                sessionOrder.Customer.ID = foundCustomer.ID;
            }
            sessionOrder.Customer.Name = customer.Name;
            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return View("Menu", customer);
        }
    }
}
