using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public class DateSelected
    {
        public int StoreId { get; set; }
        public bool WholeMonth { get; set; }
        public System.DateTime Day { get; set; }
    }
}
