using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class OnionTopping : PizzaBox.Domain.Abstracts.ATopping
    {
        private const decimal PRICE = 0.45m;

        public OnionTopping() : base(PRICE)
        {
            Name = "Onion";
            ToppingType = Abstracts.TOPPING_TYPE.Onion;
        }

        public OnionTopping(decimal price) : base(price)
        {
            Name = "Onion";
            ToppingType = Abstracts.TOPPING_TYPE.Onion;
        }
    }
}
