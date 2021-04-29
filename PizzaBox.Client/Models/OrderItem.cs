using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PizzaBox.Client.Models
{
    public class OrderItem
    {

        public OrderItem()
        {
            Order = new Order();
        }
        public Order Order { get; set; }
        public int Index { get; set; }
        public PIZZA_TYPE PizzaType { get; set; }
        public SIZE_TYPE SizeType { get; set; }
        public CRUST_TYPE CrustType { get; set; }
        public TOPPING_TYPE ToppingType { get; set; }
    }
}
