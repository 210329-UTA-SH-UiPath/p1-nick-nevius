using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public class Order
    {
        public Store Store { get; set; }
        public Customer Customer { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public System.DateTime TimePlaced { get; set; }
        public decimal Price
        {
            get
            {
                return Pizzas.Sum(p => p.Price);
            }
        }

        public Order()
        {
            TimePlaced = new System.DateTime();
            Pizzas = new List<Pizza>();
            Store = new Store();
            Customer = new Customer();
        }
    }
}
