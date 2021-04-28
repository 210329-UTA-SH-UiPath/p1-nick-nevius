using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Mappers
{
    public class SizeMapper : IMapper<PizzaBox.Storing.Entities.Size, PizzaBox.Domain.Abstracts.ASize>
    {
        public Domain.Abstracts.ASize Map(Entities.Size model)
        {
            Domain.Abstracts.ASize size;
            switch (model.SizeType)
            {
                case SIZE_TYPE.Small:
                    size = new Domain.Models.SmallSize();
                    break;
                case SIZE_TYPE.Medium:
                    size = new Domain.Models.MediumSize();
                    break;
                case SIZE_TYPE.Large:
                    size = new Domain.Models.LargeSize();
                    break;
                default:
                    throw new ArgumentException("SizeMapper encountered an unknown type when mapping from DB Model to Domain Model");
            }
            size.Price = model.Price;
            size.ID = model.ID;
            size.Name = model.Name;
            size.SizeType = model.SizeType;
            return size;
        }

        public Entities.Size Map(Domain.Abstracts.ASize model, Entities.PizzaBoxDbContext context, bool update = false)
        {
            Entities.Size size = context.Sizes.FirstOrDefault(s => s.ID == model.ID) ?? new Entities.Size();
            if (size.ID != 0 && !update)
            {
                return size;
            }
            size.SizeType = model.SizeType;
            size.Name = model.Name;
            size.Price = model.Price;
            if (size.ID == 0)
            {
                context.Sizes.Add(size);
            }
            return size;
        }
    }
}
