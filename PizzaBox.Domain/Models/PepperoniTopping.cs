using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class PepperoniTopping : PizzaBox.Domain.Abstracts.ATopping
    {
        private const decimal PRICE = 0.5m;

        public PepperoniTopping() : base(PRICE)
        {
            Name = "Pepperoni";
            ToppingType = Abstracts.TOPPING_TYPE.Pepperoni;
        }

        public PepperoniTopping(decimal price) : base(price)
        {
            Name = "Pepperoni";
            ToppingType = Abstracts.TOPPING_TYPE.Pepperoni;
        }
    }
}
