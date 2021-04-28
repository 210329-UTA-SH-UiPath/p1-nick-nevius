using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class CheeseStuffedCrust : PizzaBox.Domain.Abstracts.ACrust
    {
        private const decimal PRICE = 1.5m;

        public CheeseStuffedCrust() : base(PRICE)
        {
            Name = "Cheese Stuffed Crust";
            CrustType = Abstracts.CRUST_TYPE.CheeseStuffed;
        }

        public CheeseStuffedCrust(decimal price) : base(price)
        {
            Name = "Cheese Stuffed Crust";
            CrustType = Abstracts.CRUST_TYPE.CheeseStuffed;
        }
    }
}
