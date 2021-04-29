using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public enum CRUST_TYPE
    {
        Unknown = 0,
        CheeseStuffed,
        DeepDish,
        Traditional
    }
    public class Crust 
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public CRUST_TYPE CrustType { get; set; }
        protected Crust(decimal priceper)
        {
            Price = priceper;
        }

        public Crust()
        {

        }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
