using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Storing.Mappers;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class OrderRepository : IRepository<Domain.Models.Order>
    {
        private readonly OrderMapper mapper = new OrderMapper();
        private readonly Entities.PizzaBoxDbContext context;
        public OrderRepository(Entities.PizzaBoxDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Order t)
        {
            context.Orders.Add(mapper.Map(t, context));
            context.SaveChanges();
            //context.ChangeTracker.Clear();
        }

        public Order GetById(int id)
        {
            var dbOrder = context.Orders.Include(o => o.Customer).Include(o => o.Store)
                .Include(o => o.Pizzas).ThenInclude(p => p.Crust).Include(o => o.Pizzas)
                .ThenInclude(p => p.Size).Include(o => o.Pizzas).ThenInclude(p => p.PizzaToppings)
                .ThenInclude(pt => pt.Topping).FirstOrDefault(o => o.ID == id);
            if (dbOrder is null)
            {
                return null;
            }
            return mapper.Map(dbOrder);
        }

        public List<Domain.Models.Order> GetList()
        {
            var allOrders = context.Orders.Include(o => o.Customer).Include(o => o.Store).Include(o => o.Pizzas)
                    .ThenInclude(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).Include(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(o => o.Pizzas).ThenInclude(p => p.Crust);
            return allOrders.Select(mapper.Map).ToList();
        }

        public void Remove(int id)
        {
            Entities.Order order = context.Orders.FirstOrDefault(o => o.ID == id);
            if (order is not null)
            {
                context.Remove(order);
                context.SaveChanges();
                //context.ChangeTracker.Clear();
            }
        }

        public Domain.Models.Order Update(Domain.Models.Order updated)
        {
            Entities.Order dbOrder = mapper.Map(updated, context, true);
            context.SaveChanges();
            //context.ChangeTracker.Clear();
            return mapper.Map(dbOrder);
        }
    }
}
