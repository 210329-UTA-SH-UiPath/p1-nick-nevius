using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public enum SIZE_TYPE
    {
        Unknown = 0,
        Small,
        Medium,
        Large
    }

    public class Size
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }

        public SIZE_TYPE SizeType { get; set; }

        public decimal Price { get; set; }
        public Size(decimal priceper)
        {
            Price = priceper;
        }
        public Size()
        {

        }
    }
}
