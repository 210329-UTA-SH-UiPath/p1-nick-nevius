using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{

    public class Topping
    {
        public Topping()
        {
            //Pizzas = new List<Pizza>();
            PizzaToppings = new List<PizzaTopping>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public PizzaBox.Domain.Abstracts.TOPPING_TYPE ToppingType { get; set; }
        [Required]
        public decimal Price { get; set; }
        //public virtual ICollection<Pizza> Pizzas { get; set; }
        public string Name { get; set;  }

        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
