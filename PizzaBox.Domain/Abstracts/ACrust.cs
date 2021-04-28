using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Abstracts
{
    public enum CRUST_TYPE
    {
        Unknown = 0,
        CheeseStuffed,
        DeepDish,
        Traditional
    }
    public abstract class ACrust : AComponent
    {
        public override string ToString()
        {
            return $"{Name}";
        }

        public override decimal Price { get; set; }
        public CRUST_TYPE CrustType { get; set; }
        protected ACrust(decimal priceper)
        {
            Price = priceper;
        }

        public ACrust()
        {

        }
    }
}
