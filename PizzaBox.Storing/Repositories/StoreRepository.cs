using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class StoreRepository : IRepository<AStore>
    {
        private readonly PizzaBoxDbContext context;
        private readonly StoreMapper mapper = new StoreMapper();

        public StoreRepository(PizzaBoxDbContext context)
        {
            this.context = context;
        }

        public void Add(AStore t)
        {
            context.Add(mapper.Map(t, context));
            context.SaveChanges();
            //context.ChangeTracker.Clear();
        }

        public AStore GetById(int id)
        {
            var dbStore = context.Stores.FirstOrDefault(s => s.ID == id);
            if (dbStore is null)
            {
                return null;
            }
            return mapper.Map(dbStore);
        }

        public List<AStore> GetList()
        {
            return context.Stores.Select(mapper.Map).ToList();

        }

        public void Remove(int id)
        {
            Store existingStore = context.Stores.FirstOrDefault(store => store.ID == id);
            if (existingStore is not null)
            {
                context.Remove(existingStore);
                context.SaveChanges();
                //context.ChangeTracker.Clear();
            }
        }

        public AStore Update(AStore updated)
        {
            var mappedStore = mapper.Map(updated, context, true);
            context.SaveChanges();
            //context.ChangeTracker.Clear();
            return mapper.Map(mappedStore);
        }
    }
}
