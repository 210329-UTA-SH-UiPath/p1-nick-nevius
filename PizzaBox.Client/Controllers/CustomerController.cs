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
            return View();
        }

        
        [HttpPost]
        public IActionResult SelectedCustomer(Models.Customer cust)
        {
            if (cust is null)
            {
                return BadRequest("Customer was null somehow");
            }
            var customers = client.GetAllCustomers();
            var foundCustomer = customers.FirstOrDefault(c => c.Name.Equals(cust.Name));
            if (foundCustomer is not null)
            {
                cust.ID = foundCustomer.ID;
            }

            return View("Menu", new Models.Order { Customer = cust });
        }
    }
}
