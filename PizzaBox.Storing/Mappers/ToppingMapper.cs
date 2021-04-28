using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Mappers
{
    public class ToppingMapper : IMapper<Entities.Topping, PizzaBox.Domain.Abstracts.ATopping>
    {
        public Domain.Abstracts.ATopping Map(Entities.Topping model)
        {
            Domain.Abstracts.ATopping topping;
            switch (model.ToppingType)
            {
                case TOPPING_TYPE.Bacon:
                    topping = new Domain.Models.BaconTopping();
                    break;
                case TOPPING_TYPE.Mushroom:
                    topping = new Domain.Models.MushroomTopping();
                    break;
                case TOPPING_TYPE.Onion:
                    topping = new Domain.Models.OnionTopping();
                    break;
                case TOPPING_TYPE.Pepperoni:
                    topping = new Domain.Models.PepperoniTopping();
                    break;
                default:
                    throw new ArgumentException("ToppingMapper encountered unknown topping type when mapping from DB Model to Domain Model");
            }

            topping.Price = model.Price;
            topping.ID = model.ID;
            topping.Name = model.Name;
            topping.ToppingType = model.ToppingType;
            return topping;
        }

        public Entities.Topping Map(Domain.Abstracts.ATopping model, Entities.PizzaBoxDbContext context, bool update = false)
        {
            Entities.Topping topping = context.Toppings.FirstOrDefault(t => t.ID == model.ID) ?? new Entities.Topping();
            if (topping.ID != 0 && !update)
            {
                return topping;
            }
            topping.ToppingType = model.ToppingType;
            topping.Name = model.Name;
            topping.Price = model.Price;
            if (topping.ID == 0)
            {
                context.Toppings.Add(topping);
            }
            return topping;
        }
    }
}
