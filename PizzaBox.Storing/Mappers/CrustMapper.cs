using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Mappers
{
    public class CrustMapper : IMapper<PizzaBox.Storing.Entities.Crust, PizzaBox.Domain.Abstracts.ACrust>
    {
        public Domain.Abstracts.ACrust Map(Entities.Crust model)
        {
            Domain.Abstracts.ACrust crust = null;
            switch (model.CrustType)
            {
                case CRUST_TYPE.CheeseStuffed:
                    crust = new CheeseStuffedCrust();
                    break;
                case CRUST_TYPE.DeepDish:
                    crust = new DeepDishCrust();
                    break;
                case CRUST_TYPE.Traditional:
                    crust = new TraditionalCrust();
                    break;
                case CRUST_TYPE.Unknown:
                // TODO: add logging to these last 2
                default:
                    throw new ArgumentException("CrustMapper ran into an unknown Crust Type when mapping from DB Model to Domain Model");
            }
            crust.Price = model.Price;
            crust.ID = model.ID;
            crust.Name = model.Name;
            crust.CrustType = model.CrustType; // not really needed
            return crust;
        }

        public Entities.Crust Map(Domain.Abstracts.ACrust model, Entities.PizzaBoxDbContext context, bool update = false)
        {
            Entities.Crust crust = context.Crusts.FirstOrDefault(crust => crust.ID == model.ID) ?? new Entities.Crust();
            if (crust.ID != 0 && !update)
            {
                return crust;
            }

            // either we are updating and we want to cascade all changes
            // or it didn't exist and we need to instantiate it
            crust.CrustType = model.CrustType;
            crust.Price = model.Price;
            crust.Name = model.Name;

            // if it is new, insert it into context so a future map can find it
            if (crust.ID == 0)
            {
                context.Crusts.Add(crust);
            }
            return crust;
        }
    }
}
