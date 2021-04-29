using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public class OrderHistory
    {
        public int StoreId { get; set; }
        public bool All { get; set; }
        public Customer Customer { get; set; }
    }
}
