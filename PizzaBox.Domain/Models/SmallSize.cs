using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class SmallSize : PizzaBox.Domain.Abstracts.ASize
    {
        private const decimal PRICE = 3.0m;

        public SmallSize() : base(PRICE)
        {
            Name = "Small Size";
            SizeType = Abstracts.SIZE_TYPE.Small;
        }

        public SmallSize(decimal price) : base(price)
        {
            Name = "Small Size";
            SizeType = Abstracts.SIZE_TYPE.Small;
        }
    }
}
