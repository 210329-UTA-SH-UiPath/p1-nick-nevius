using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public class RemoveItem
    {
        public Order Order { get; set; }

        // will either be an entire Pizza or a Topping
        // can be casted in the appropriate controllers
        public int Index { get; set; }

        public RemoveItem()
        {
            Index = -1;
        }
    }
}
