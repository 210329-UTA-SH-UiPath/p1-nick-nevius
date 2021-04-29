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
        public IActionResult StoreHistoryDetails(int ID)
        {
            // have this be the exact same as the other one
            // except it goes back to a different route when clicking bacl
            var order = client.GetAllOrders().FirstOrDefault(o => o.ID == ID);
            if (order is null)
            {
                return BadRequest("Order does not exist");
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult StoreCustomerHistoryDetails(int ID)
        {
            // have this be the exact same as the other one
            // except it goes back to a different route when clicking bacl
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

            // should probably redirect them to some other page?
            //return null;
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public IActionResult SelectSalesReport (int StoreID)
        {
            /*
             * if option for sales report
    should be able to view revenue by week (inlcuding pizza type and count per type)
    should be able to view revenue by month (including pizza type and count per type) 
             */
            return View(new Models.DateSelected() { WholeMonth = true, StoreId = StoreID });
        }

        [HttpPost]
        public IActionResult DateSelected(Models.DateSelected date)
        {
            // get all orders based on the day and the checkbox
            // show:
            //      should be able to view revenue by week (inlcuding pizza type and count per type)
            //      should be able to view revenue by month(including pizza type and count per type)


            // return a view with either ViewBag set to stuff
            // or passing it in as a Model, either works
            return null;
        }

        [HttpGet]
        public IActionResult SelectOrderHistory(int StoreID)
        {
            // already have store selected
            // but we need to know if we want ALL orders or just for a specific customer
            return View(new Models.OrderHistory() { All = true, StoreId = StoreID });
        }

        public IActionResult StoreHistory(int storeID)
        {
            var orders = client.GetAllOrders().Where(o => o.Store.ID == storeID);
            return View("StoreOrderHistory", orders);
        }

        public IActionResult StoreCustomerHistory(int storeID, string customerName)
        {
            var orders = client.GetAllOrders().Where(o => o.Store.ID == storeID &&
                                                          o.Customer.Name.Equals(customerName));
            return View("StoreCustomerOrderHistory", orders);
        }

        [HttpPost]
        public IActionResult HistorySelected(Models.OrderHistory historyOptions)
        {
            /*
             *  if option for store orders
                should be able to view order history
                if option for store orders by customer (filtering)
                should be able to view order history for a customer
             */

            if (historyOptions.All)
            {
                return RedirectToAction("StoreHistory", new { storeID = historyOptions.StoreId });
            }
            else
            {
                // Can use /STOREHISTORY/ combo of customer name and store ID
                return RedirectToAction("StoreCustomerHistory", new { storeID = historyOptions.StoreId,
                                                               customerName = historyOptions.Customer.Name});
            }
        }

    }
}
