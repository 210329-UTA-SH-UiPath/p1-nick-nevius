using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class ChicagoStore : PizzaBox.Domain.Abstracts.AStore
    {
        public ChicagoStore()
        {
            Name = "ChicagoStore";
            StoreType = Abstracts.STORE_TYPE.Chicago;
        }

        public override string ToString()
        {
            return $"This is Chitown - {Name}";
        }
    }
}
