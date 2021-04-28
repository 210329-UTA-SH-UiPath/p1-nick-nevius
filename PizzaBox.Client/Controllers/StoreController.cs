using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Controllers
{
    public class StoreController : Controller
    {
        private readonly Client client = null;

        public StoreController(Client client)
        {
            this.client = client;
        }

        [HttpPost]
        public IActionResult StoreSelected(Models.Order order)
        {
            var store = client.GetAllStores().FirstOrDefault(s => s.ID == order.Store.ID);
            if (store is null)
            {
                return BadRequest("Store you selected was somehow null");
            }
            order.Store.Name = store.Name;
            order.Store.StoreType = store.StoreType;

            return View();
        }
    }
}
