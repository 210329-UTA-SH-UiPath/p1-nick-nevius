using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class MediumSize : PizzaBox.Domain.Abstracts.ASize
    {
        private const decimal PRICE = 4.0m;

        public MediumSize() : base(PRICE)
        {
            Name = "Medium Size";
            SizeType = Abstracts.SIZE_TYPE.Medium;
        }

        public MediumSize(decimal price) : base(price)
        {
            Name = "Medium Size";
            SizeType = Abstracts.SIZE_TYPE.Medium;
        }
    }
}
