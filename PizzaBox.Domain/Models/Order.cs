using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Order : ASellable
    {
        public AStore Store { get; set; }
        public Customer Customer { get; set; }
        public List<APizza> Pizzas { get; set; }

        public System.DateTime TimePlaced { get; set; }

        public override decimal Price
        {
            get
            {
                decimal Total = 0.0m;
                Pizzas.ForEach(pizza => Total += pizza.Price);
                return Total;
            }
            set
            {

            }
        }

        public override string ToString()
        {
            string result = $"{Customer}" + System.Environment.NewLine + $"{TimePlaced}"
                            + System.Environment.NewLine + $"{Store}" + System.Environment.NewLine
                            + $"{Price}" + System.Environment.NewLine + "Pizzas:" + System.Environment.NewLine;
            Pizzas.ForEach(pizza => result += $"{pizza}" + System.Environment.NewLine);
            return result;
        }



        public Order()
        {
            TimePlaced = new System.DateTime();
            Pizzas = new List<APizza>();
        }
    }
}
