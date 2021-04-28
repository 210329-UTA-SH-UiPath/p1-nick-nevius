using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Mappers
{
    public class OrderMapper : IMapper<Entities.Order, Domain.Models.Order>
    {
        private CustomerMapper customerMapper = new CustomerMapper();
        private PizzaMapper pizzaMapper = new PizzaMapper();
        private StoreMapper storeMapper = new StoreMapper();

        public Domain.Models.Order Map(Entities.Order model)
        {
            Domain.Models.Order order = new Domain.Models.Order();
            order.Customer = customerMapper.Map(model.Customer);

            List<Domain.Abstracts.APizza> apizzas = new List<Domain.Abstracts.APizza>();
            model.Pizzas.ToList().ForEach(p => apizzas.Add(pizzaMapper.Map(p)));
            order.Pizzas = apizzas;

            order.Price = model.TotalPrice;
            order.Store = storeMapper.Map(model.Store);
            order.TimePlaced = model.TimePlaced;

            order.ID = model.ID;
            return order;
        }

        public Entities.Order Map(Domain.Models.Order model, Entities.PizzaBoxDbContext context, bool update = false)
        {
            Entities.Order order = context.Orders.Include(o => o.Customer).Include(o => o.Store).Include(o => o.Pizzas)
                    .ThenInclude(p => p.PizzaToppings).ThenInclude(pt => pt.Topping).Include(o => o.Pizzas).ThenInclude(p => p.Size)
                    .Include(o => o.Pizzas).ThenInclude(p => p.Crust).FirstOrDefault(o => o.ID == model.ID) ?? new Entities.Order();

            //Entities.Order order = context.Orders.FirstOrDefault(o => o.ID == model.ID) ?? new Entities.Order();
            if (order.ID != 0 && !update)
            {
                return order;
            }

            order.Customer = customerMapper.Map(model.Customer, context, update);
            order.Pizzas.Clear();
            foreach (Domain.Abstracts.APizza pizza in model.Pizzas)
            {
                var mappedPizza = pizzaMapper.Map(pizza, context, update);
                mappedPizza.Order = order;
                order.Pizzas.Add(mappedPizza);
            }

            //model.Pizzas.ForEach(p => pizzas.Add(pizzaMapper.Map(p, context)));

            order.Store = storeMapper.Map(model.Store, context, update);
            order.TotalPrice = model.Price;
            order.TimePlaced = DateTime.Now;

            if (order.ID == 0)
            {
                context.Orders.Add(order);
            }
            return order;
        }
    }
}
