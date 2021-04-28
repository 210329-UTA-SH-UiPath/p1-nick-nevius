using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class DeepDishCrust : PizzaBox.Domain.Abstracts.ACrust
    {
        private const decimal PRICE = 1.5m;

        public DeepDishCrust() : base(PRICE)
        {
            Name = "Deep Dish Crust";
            CrustType = Abstracts.CRUST_TYPE.DeepDish;
        }

        public DeepDishCrust(decimal price) : base(price)
        {
            Name = "Deep Dish Crust";
            CrustType = Abstracts.CRUST_TYPE.DeepDish;
        }
    }
}
