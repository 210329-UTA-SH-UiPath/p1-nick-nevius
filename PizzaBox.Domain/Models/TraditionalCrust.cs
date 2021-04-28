using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    public class TraditionalCrust : PizzaBox.Domain.Abstracts.ACrust
    {
        private const decimal PRICE = 1.0m;

        public TraditionalCrust() : base(PRICE)
        {
            Name = "Traditional Crust";
            CrustType = Abstracts.CRUST_TYPE.Traditional;
        }

        public TraditionalCrust(decimal price) : base(price)
        {
            Name = "Traditional Crust";
            CrustType = Abstracts.CRUST_TYPE.Traditional;
        }
    }
}
