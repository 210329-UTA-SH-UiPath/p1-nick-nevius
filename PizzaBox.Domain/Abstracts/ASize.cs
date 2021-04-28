using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Abstracts
{
    public enum SIZE_TYPE
    {
        Unknown = 0,
        Small,
        Medium,
        Large
    }

    public abstract class ASize : AComponent
    {
        public override string ToString()
        {
            return $"{Name}";
        }

        public SIZE_TYPE SizeType { get; set; }

        public override decimal Price { get; set; }
        protected ASize(decimal priceper)
        {
            Price = priceper;
        }
    }
}
