using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public int ID { get; set; }
        private string _name = null;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Customer(string name)
        {
            Name = name;
            ID = 0;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
