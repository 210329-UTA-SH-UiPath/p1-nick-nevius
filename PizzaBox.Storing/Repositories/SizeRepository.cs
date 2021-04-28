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
    public class SizeRepository : IRepository<Domain.Abstracts.ASize>
    {
        private readonly PizzaBoxDbContext context;
        private readonly SizeMapper mapper = new SizeMapper();

        public SizeRepository(PizzaBoxDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Abstracts.ASize t)
        {
            context.Add(mapper.Map(t, context));
            context.SaveChanges();
            //context.ChangeTracker.Clear();
        }

        public ASize GetById(int id)
        {
            var dbSize = context.Sizes.FirstOrDefault(s => s.ID == id);
            if (dbSize is null)
            {
                return null;
            }
            return mapper.Map(dbSize);
        }

        public List<Domain.Abstracts.ASize> GetList()
        {
            return context.Sizes.Select(mapper.Map).ToList();

            //List<Domain.Models.Size> sizes = new List<Domain.Models.Size>();
            //context.Sizes.AsEnumerable().GroupBy(s => s.SizeType).Select(s => s.First()).ToList().ForEach(size => sizes.Add(mapper.Map(size)));
            //return sizes;
        }

        public void Remove(int id)
        {
            Entities.Size size = context.Sizes.FirstOrDefault(s => s.ID == id);
            if (size is not null)
            {
                context.Remove(size);
                context.SaveChanges();
                //context.ChangeTracker.Clear();
            }
        }

        public Domain.Abstracts.ASize Update(Domain.Abstracts.ASize updated)
        {
            Entities.Size dbSize = mapper.Map(updated, context, true);
            context.SaveChanges();
            //context.ChangeTracker.Clear();
            return mapper.Map(dbSize);
        }
    }
}
