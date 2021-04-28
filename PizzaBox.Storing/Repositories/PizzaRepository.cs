using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Mappers;
using PizzaBox.Storing.Entities;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class PizzaRepository : IRepository<APizza>
    {
        private readonly PizzaMapper mapper = new PizzaMapper();
        private readonly PizzaBoxDbContext context;
        public PizzaRepository(PizzaBoxDbContext context)
        {
            this.context = context;
        }

        public void Add(APizza t)
        {
            context.Pizzas.Add(mapper.Map(t, context));
            context.SaveChanges();
            //context.ChangeTracker.Clear();
        }

        public APizza GetById(int id)
        {
            var dbPizza = context.Pizzas.FirstOrDefault(p => p.ID == id);
            if (dbPizza is null)
            {
                return null;
            }
            return mapper.Map(dbPizza);
        }

        public List<APizza> GetList()
        {
            var allPizzas = context.Pizzas.Include(p => p.Order).Include(p => p.Crust).Include(p => p.Size).Include(p => p.PizzaToppings)
                .Include(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).Include(p => p.PizzaToppings)
                .ThenInclude(pt => pt.Pizza).AsEnumerable().GroupBy(p => p.PizzaType).Select(p => p.First());
            return allPizzas.Select(mapper.Map).ToList();
        }

        public void Remove(int id)
        {
            Pizza pizza = context.Pizzas.FirstOrDefault(p => p.ID == id);
            if (pizza is not null)
            {
                context.Remove(pizza);
                context.SaveChanges();
                //context.ChangeTracker.Clear();
            }
        }

        public APizza Update(APizza updated)
        {
            var dbPizza = mapper.Map(updated, context, true);
            context.SaveChanges();
            //context.ChangeTracker.Clear();
            return mapper.Map(dbPizza);
        }
    }
}
