using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class ASellable
    {
        public abstract decimal Price { get; set; }
        public int ID { get; set; }
        public ASellable()
        {
            ID = 0;
        }
    }
}
