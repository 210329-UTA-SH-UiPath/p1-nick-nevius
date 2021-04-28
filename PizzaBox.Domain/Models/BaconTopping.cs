using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class BaconTopping : PizzaBox.Domain.Abstracts.ATopping
    {
        private const decimal PRICE = 0.5m;

        public BaconTopping() : base(PRICE)
        {
            Name = "Bacon";
            ToppingType = Abstracts.TOPPING_TYPE.Bacon;
        }

        public BaconTopping(decimal price) : base(price)
        {
            Name = "Bacon";
            ToppingType = Abstracts.TOPPING_TYPE.Bacon;
        }
    }
}
