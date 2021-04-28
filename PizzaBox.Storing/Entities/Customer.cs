using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
