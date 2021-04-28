using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Abstracts
{
    public enum TOPPING_TYPE
    {
        Unknown = 0,
        Bacon,
        Mushroom,
        Onion,
        Pepperoni
    }
    public abstract class ATopping : AComponent
    {
        public override decimal Price { get; set; }
        protected ATopping(decimal priceper)
        {
            Price = priceper;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public TOPPING_TYPE ToppingType { get; set; }
    }
}
