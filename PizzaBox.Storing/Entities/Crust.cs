using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{


    public class Crust
    {
        public Crust()
        {
            Pizzas = new List<Pizza>();
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public PizzaBox.Domain.Abstracts.CRUST_TYPE CrustType { get; set; }
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
