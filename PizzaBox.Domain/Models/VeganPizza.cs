using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class VeganPizza : APizza
    {
        public VeganPizza() : base("Vegan Pizza")
        {
            PizzaType = PIZZA_TYPE.Vegan;
        }

        public override void AddCrust()
        {
            Crust = new CheeseStuffedCrust();
        }

        public override void AddSize()
        {
            Size = new MediumSize();
        }

        public override void AddToppings()
        {
            //Toppings.AddRange(new ATopping[] { new MushroomTopping(), new OnionTopping() });
        }

        public override APizza Clone()
        {
            return new VeganPizza();
        }
    }
}
