using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
    public class ToppingRepository : IRepository<ATopping>
    {
        private readonly PizzaBoxDbContext context;
        private readonly ToppingMapper mapper = new ToppingMapper();
        public ToppingRepository(PizzaBoxDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Abstracts.ATopping t)
        {
            context.Toppings.Add(mapper.Map(t, context));
            context.SaveChanges();
            //context.ChangeTracker.Clear();
        }

        public ATopping GetById(int id)
        {
            var dbTopping = context.Toppings.FirstOrDefault(t => t.ID == id);
            if (dbTopping is null)
            {
                return null;
            }
            return mapper.Map(dbTopping);
        }

        public List<Domain.Abstracts.ATopping> GetList()
        {
            return context.Toppings.Select(mapper.Map).ToList();
        }

        public void Remove(int id)
        {
            Entities.Topping topping = context.Toppings.FirstOrDefault(t => t.ID == id);
            if (topping is not null)
            {
                context.Remove(topping);
                context.SaveChanges();
                //context.ChangeTracker.Clear();
            }
        }

        public Domain.Abstracts.ATopping Update(Domain.Abstracts.ATopping updated)
        {
            Entities.Topping topping = mapper.Map(updated, context, true);
            context.SaveChanges();
            //context.ChangeTracker.Clear();
            return mapper.Map(topping);
        }
    }
}
