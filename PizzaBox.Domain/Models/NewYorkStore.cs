using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class NewYorkStore : PizzaBox.Domain.Abstracts.AStore
    {

        public NewYorkStore()
        {
            Name = "NewYorkStore";
            StoreType = Abstracts.STORE_TYPE.NewYork;
        }

        public override string ToString()
        {
            return $"This is New York - {Name}";
            StoreType = Abstracts.STORE_TYPE.NewYork;
        }
    }
}
