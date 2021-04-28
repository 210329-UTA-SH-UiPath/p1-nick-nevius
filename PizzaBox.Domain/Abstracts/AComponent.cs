using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AComponent : ASellable
    {
        public string Name { get; set; }
    }
}
