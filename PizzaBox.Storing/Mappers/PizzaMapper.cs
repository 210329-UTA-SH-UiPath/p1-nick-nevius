using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;
using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Mappers
{
    public class PizzaMapper : IMapper<Pizza, APizza>
    {
        private CrustMapper crustMapper = new CrustMapper();
        private SizeMapper sizeMapper = new SizeMapper();
        private ToppingMapper toppingMapper = new ToppingMapper();

        public APizza Map(Pizza model)
        {
            APizza pizza;
            switch (model.PizzaType)
            {
                case PIZZA_TYPE.Meat:
                    pizza = new MeatPizza();
                    break;
                case PIZZA_TYPE.Vegan:
                    pizza = new VeganPizza();
                    break;
                case PIZZA_TYPE.Custom:
                    pizza = new CustomPizza();
                    break;
                default:
                    throw new ArgumentException("PizzaMapper encountered an unknown type when mapping from DB Model to Domain Model");
            }

            pizza.Crust = crustMapper.Map(model.Crust);
            pizza.Size = sizeMapper.Map(model.Size);
            List<ATopping> toppings = new List<ATopping>();
            model.PizzaToppings.ToList().ForEach(pt =>
            {
                for (int i = 0; i < pt.Amount; i++)
                {
                    toppings.Add(toppingMapper.Map(pt.Topping));
                }
            });
            pizza.Toppings = toppings;
            
            // TODO: check why this was commented out??????????
            //pizza.Price = model.Price;
            pizza.ID = model.ID;
            return pizza;
        }

        public Pizza Map(APizza model, Entities.PizzaBoxDbContext context, bool update = false)
        {
            Pizza pizza = context.Pizzas.Include(p => p.Order).Include(p => p.Crust).Include(p => p.Size).Include(p => p.PizzaToppings)
                .ThenInclude(pt => pt.Topping).Include(p => p.PizzaToppings).ThenInclude(pt => pt.Pizza).FirstOrDefault(p => p.ID == model.ID) ?? new Pizza();

            //Pizza pizza = context.Pizzas.FirstOrDefault(p => p.ID == model.ID) ?? new Pizza();
            if (pizza.ID != 0 && !update)
            {
                return pizza;
            }
            pizza.PizzaType = model.PizzaType;
            pizza.Crust = crustMapper.Map(model.Crust, context, update);
            pizza.Size = sizeMapper.Map(model.Size, context, update);
            pizza.Name = model.Name;

            // need to group the PizzaToppings by their topping's toppingtype
            // need to make AMOUNT = Count of the grouping
            List<Entities.Topping> mappedToppings = new List<Entities.Topping>();
            model.Toppings.ForEach(t => mappedToppings.Add(toppingMapper.Map(t, context, update)));
            pizza.PizzaToppings.Clear();
            foreach (var group in mappedToppings.GroupBy(t => t.ToppingType))
            {
                var firstTopping = group.Last();
                if (firstTopping is null)
                {
                    // Should never happen
                    throw new ArgumentException("Everything is on fire. Just rewrite everything please");
                }
                PizzaTopping pt = context.PizzaToppings.Include(pt => pt.Pizza).Include(pt => pt.Topping)
                                .FirstOrDefault(pt => pt.Pizza.ID == pizza.ID &&
                                                pt.Topping.ID == firstTopping.ID) ?? new PizzaTopping();
                if (pt.ID != 0 && !update)
                {
                    // TODO: check if this is needed
                    //pizza.PizzaToppings.Add(pt);
                    continue;
                }

                //it either isn't already in the DB or we need to update it if it does exist
                pt.Pizza = pizza;
                pt.Topping = firstTopping;
                pt.Amount = group.Count();

                //firstTopping.PizzaToppings.Add(pt);
                pizza.PizzaToppings.Add(pt);
            }

            pizza.Price = model.Price;
            if (pizza.ID == 0)
            {
                context.Pizzas.Add(pizza);
            }
            return pizza;
        }
    }
}
