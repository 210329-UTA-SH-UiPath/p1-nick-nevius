using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{

    public class Size
    {
        public Size()
        {
            Pizzas = new List<Pizza>();
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public PizzaBox.Domain.Abstracts.SIZE_TYPE SizeType { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Name { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }
    }
}
