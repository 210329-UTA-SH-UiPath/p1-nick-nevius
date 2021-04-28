using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
    public class CustomerRepository : IRepository<PizzaBox.Domain.Models.Customer>
    {
        private readonly CustomerMapper mapper = new CustomerMapper();
        private readonly PizzaBoxDbContext context;
        public CustomerRepository(PizzaBoxDbContext context)
        {
            this.context = context;
        }


        public void Add(Domain.Models.Customer t)
        {
            context.Customers.Add(mapper.Map(t, context));
            context.SaveChanges();
            //context.ChangeTracker.Clear();

        }

        public Domain.Models.Customer GetById(int id)
        {
            var dbCust = context.Customers.FirstOrDefault(c => c.ID == id);
            if (dbCust is null)
            {
                return null;
            }
            return mapper.Map(dbCust);
        }

        public List<Domain.Models.Customer> GetList()
        {
            return context.Customers.Select(mapper.Map).ToList();
        }

        public void Remove(int id)
        {
            PizzaBox.Storing.Entities.Customer customer = context.Customers.FirstOrDefault(customer => customer.ID == id);
            if (customer is not null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
                //context.ChangeTracker.Clear();
            }
        }

        public Domain.Models.Customer Update(Domain.Models.Customer updated)
        {
            Entities.Customer mappedCust = mapper.Map(updated, context, true);
            context.SaveChanges();
            //context.ChangeTracker.Clear();
            return mapper.Map(mappedCust);
        }
    }
}
