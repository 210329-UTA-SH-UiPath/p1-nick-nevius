using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public enum TOPPING_TYPE
    {
        Unknown = 0,
        Bacon,
        Mushroom,
        Onion,
        Pepperoni
    }
    public class Topping
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public TOPPING_TYPE ToppingType { get; set; }

        public Topping(decimal priceper)
        {
            Price = priceper;
        }

        public Topping()
        {

        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
