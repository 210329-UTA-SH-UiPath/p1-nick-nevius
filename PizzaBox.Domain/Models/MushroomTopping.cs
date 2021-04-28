using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class MushroomTopping : PizzaBox.Domain.Abstracts.ATopping
    {
        private const decimal PRICE = 0.6m;

        public MushroomTopping() : base(PRICE)
        {
            Name = "Mushroom";
            ToppingType = Abstracts.TOPPING_TYPE.Mushroom;
        }

        public MushroomTopping(decimal price) : base(price)
        {
            Name = "Mushroom";
            ToppingType = Abstracts.TOPPING_TYPE.Mushroom;
        }
    }
}
