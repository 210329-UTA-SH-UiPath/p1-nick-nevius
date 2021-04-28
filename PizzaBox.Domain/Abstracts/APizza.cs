using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Abstracts
{
    public enum PIZZA_TYPE
    {
        Unknown = 0,
        Custom,
        Meat,
        Vegan
    }

    public abstract class APizza : ASellable
    {
        public ACrust Crust { get; set; }
        public ASize Size { get; set; }

        public List<ATopping> Toppings { get; set; }
        public string Name { get; set; }
        public PIZZA_TYPE PizzaType { get; set; }
        private decimal price = 0.0m;
        public override decimal Price
        {
            get
            {
                if (price != 0.0m)
                {
                    return price;
                }
                price += Crust.Price;
                price += Size.Price;
                foreach (ATopping topping in Toppings)
                {
                    price += topping.Price;
                }
                return price;
            }
            set
            {
                price = value;
            }
        }

        public override string ToString()
        {
            if (this is PizzaBox.Domain.Models.CustomPizza)
            {
                string output = $"Custom Pizza - {Price}" + Environment.NewLine + $"\tCrust: {Crust}" + Environment.NewLine + $"\tSize: {Size}" + Environment.NewLine + "\tToppings: ";
                Toppings.ForEach(topping => output += topping.ToString() + ", ");
                var lastIndex = output.LastIndexOf(", ");
                if (lastIndex != -1)
                {
                    output = output.Substring(0, lastIndex);
                }
                return output;
            }

            return $"{Name} - {Price}";
        }

        protected APizza(String name)
        {
            Name = name;
            Factory();
        }

        private void Factory()
        {
            Toppings = new List<ATopping>();

            AddCrust();
            AddSize();
            AddToppings();
        }

        public abstract void AddCrust();

        public abstract void AddSize();

        public abstract void AddToppings();

        public abstract APizza Clone();
    }
}
