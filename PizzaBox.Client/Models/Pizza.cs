using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public enum PIZZA_TYPE
    {
        Unknown = 0,
        Custom,
        Meat,
        Vegan
    }

    public class Pizza
    {
        //https://stackoverflow.com/questions/17662716/how-to-handle-an-edit-and-delete-button-on-the-same-form-in-asp-net-mvc
        public List<Topping> Toppings { get; set; }
        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public string Name { get; set; }
        public PIZZA_TYPE PizzaType { get; set; }

        private decimal price = 0.0m;
        public decimal Price
        {
            get
            {
                if (price != 0.0m)
                {
                    return price;
                }
                price += Crust.Price;
                price += Size.Price;
                price += Toppings.Sum(t => t.Price);
                return price;
            }
            set
            {
                price = value;
            }
        }

        public override string ToString()
        {
            if (PizzaType == PIZZA_TYPE.Custom)
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

        public Pizza()
        {
            Factory();
        }

        public Pizza(String name)
        {
            Name = name;
            Factory();
        }

        private void Factory()
        {
            Toppings = new List<Topping>();
        }
    }
}
