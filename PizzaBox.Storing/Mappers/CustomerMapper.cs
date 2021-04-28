using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Storing.Mappers
{
    public class CustomerMapper : IMapper<PizzaBox.Storing.Entities.Customer, PizzaBox.Domain.Models.Customer>
    {
        public Domain.Models.Customer Map(Entities.Customer model)
        {
            Domain.Models.Customer cust = new Domain.Models.Customer(model.Name);
            cust.ID = model.ID;
            return cust;
        }

        public Entities.Customer Map(Domain.Models.Customer model, Entities.PizzaBoxDbContext context, bool update = false)
        {
            Entities.Customer customer = context.Customers.FirstOrDefault(cust => cust.ID == model.ID) ?? new Entities.Customer();
            if (customer.ID != 0 && !update)
            {
                return customer;
            }
            customer.Name = model.Name;

            if (customer.ID == 0)
            {
                context.Customers.Add(customer);
            }
            return customer;
        }
    }
}
