using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models
{
    public class CustomPizza : PizzaBox.Domain.Abstracts.APizza
    {
        public CustomPizza() : base("Custom Pizza")
        {
            PizzaType = PIZZA_TYPE.Custom;
        }

        public override void AddCrust()
        {

        }

        public override void AddSize()
        {

        }

        public override void AddToppings()
        {
            // TODO: check if this is even needed. Pretty sure it isn't due to changing the factory method
            //Toppings = new System.Collections.Generic.List<Topping>();
        }

        public override PizzaBox.Domain.Abstracts.APizza Clone()
        {
            return new CustomPizza();
        }
    }
}
