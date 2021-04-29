using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public class ListItem
    {
        public int Index { get; set; }
        public Object Item { get; set; }
        public string Name
        {
            get
            {
                // there HAS to be a better way to do this than reflection :(
                return Item.GetType().GetProperty("Name").GetValue(Item, null) as string;
            }
        }
    }
}
