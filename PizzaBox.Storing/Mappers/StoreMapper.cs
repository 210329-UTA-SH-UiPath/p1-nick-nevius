using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Storing.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Mappers
{
    public class StoreMapper : IMapper<Store, AStore>
    {
        public AStore Map(Store model)
        {
            AStore aStore = null;
            switch (model.StoreType)
            {
                case STORE_TYPE.Chicago:
                    aStore = new ChicagoStore();
                    break;
                case STORE_TYPE.NewYork:
                    aStore = new NewYorkStore();
                    break;
                case STORE_TYPE.Unknown:
                // TODO: add logging to these last 2
                default:
                    throw new ArgumentException("Store mapper is attempting to map a store type that does not exist in the codebase");
            }
            aStore.Name = model.Name;
            aStore.StoreType = model.StoreType;
            aStore.ID = model.ID;
            return aStore;
        }

        public Store Map(AStore model, Entities.PizzaBoxDbContext context, bool update = false)
        {
            Store store = context.Stores.FirstOrDefault(s => s.ID == model.ID) ?? new Store();
            if (store.ID != 0 && !update)
            {
                return store;
            }
            store.Name = model.Name;
            store.StoreType = model.StoreType;
            if (store.ID == 0)
            {
                context.Stores.Add(store);
            }
            return store;
        }
    }
}
