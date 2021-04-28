using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class LargeSize : PizzaBox.Domain.Abstracts.ASize
    {
        private const decimal PRICE = 4.5m;

        public LargeSize() : base(PRICE)
        {
            Name = "Large Size";
            SizeType = Abstracts.SIZE_TYPE.Large;
        }

        public LargeSize(decimal price) : base(price)
        {
            Name = "Large Size";
            SizeType = Abstracts.SIZE_TYPE.Large;
        }
    }
}
