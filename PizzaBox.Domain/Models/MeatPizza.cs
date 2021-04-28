using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class MeatPizza : APizza
    {
        public MeatPizza() : base("Meat Pizza")
        {
            PizzaType = PIZZA_TYPE.Meat;
        }

        public override void AddToppings()
        {
            //Toppings.AddRange(new ATopping[] { new PepperoniTopping(), new BaconTopping() });
        }

        public override void AddSize()
        {
            Size = new MediumSize();
        }

        public override void AddCrust()
        {
            Crust = new TraditionalCrust();
        }

        public override APizza Clone()
        {
            return new MeatPizza();
        }
    }
}
