using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpPost]
        public IActionResult CustomerOrderHistory(Models.Order order)
        {
            var orders = client.GetAllOrders().Where(o => o.Customer.Name.Equals(order.Customer.Name));
            return View("CustomerOrderHistory", orders);
        }

        [HttpPost]
        public IActionResult Init(Models.Order order)
        {
            // get list of available stores and pass them in through a viewbag
            // then have customer select a store and then post to adding a new Pizza


            // all of the customers orders, sorted by newest to oldest
            var customerOrders = client.GetAllOrders().Where(o => o.Customer.Name.Equals(order.Customer.Name))
                                    .OrderByDescending(o => o.TimePlaced).ToList();
            if (customerOrders.Count > 0)
            {
                var timeDifference = System.DateTime.Now - customerOrders.First().TimePlaced;
                if (timeDifference.TotalHours < 2)
                {
                    // can't place order since it has been less than 2 hours
                    return BadRequest("No stores are valid for the selected customer");
                }
            }

            // get the newest order placed by this customer for each store (because list is already ordered by newest)
            var storeOrders = customerOrders.GroupBy(o => o.Store.Name).Select(s => s.First());

            List<Models.Store> validStores = new List<Models.Store>();
            foreach(var store in client.GetAllStores())
            {
                var lastOrderFromStore = storeOrders.FirstOrDefault(o => o.Store.Name.Equals(store.Name));
                if (lastOrderFromStore is not null)
                {
                    var timeDifference = System.DateTime.Now - lastOrderFromStore.TimePlaced;
                    if (timeDifference.TotalSeconds > 60 * 60 * 24)
                    {
                        validStores.Add(store);
                    }
                }
                else
                {
                    // customer has never ordered from store so it is valid
                    validStores.Add(store);
                }
            }

            if (validStores.Count == 0)
            {
                // no stores are actually valid
                return BadRequest("No stores are valid for the selected customer");
            }


            // add valid stores to viewbag and then let customer select one
            ViewBag.Stores = new SelectList(validStores.ToList(), "ID", "Name");

            return View(order);
        }
    }
}
