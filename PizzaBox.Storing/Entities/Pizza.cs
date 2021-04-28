using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{


    public class Pizza
    {
        public Pizza()
        {
            //Toppings = new List<Topping>();
            PizzaToppings = new List<PizzaTopping>();
            //Order = new Order();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public PizzaBox.Domain.Abstracts.PIZZA_TYPE PizzaType { get; set; }
        [Required]
        public virtual Crust Crust { get; set; }
        [Required]
        public virtual Size Size { get; set; }
        [Required]
        //public virtual ICollection<Topping> Toppings { get; set; }
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Name { get; set; }
        [Required]
        public virtual Order Order { get; set; }
    }
}
