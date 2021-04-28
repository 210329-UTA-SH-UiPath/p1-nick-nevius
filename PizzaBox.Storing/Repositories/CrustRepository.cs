using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
    public class CrustRepository : IRepository<PizzaBox.Domain.Abstracts.ACrust>
    {

        private readonly PizzaBoxDbContext context;
        private readonly CrustMapper mapper = new CrustMapper();

        public CrustRepository(PizzaBoxDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Abstracts.ACrust t)
        {
            context.Crusts.Add(mapper.Map(t, context));
            context.SaveChanges();
            //context.ChangeTracker.Clear();
        }

        public ACrust GetById(int id)
        {
            var dbCrust = context.Crusts.FirstOrDefault(c => c.ID == id);
            if (dbCrust is null)
            {
                return null;
            }
            return mapper.Map(dbCrust);
        }

        public List<Domain.Abstracts.ACrust> GetList()
        {
            return context.Crusts.Select(mapper.Map).ToList();
        }

        public void Remove(int id)
        {
            Entities.Crust crust = context.Crusts.FirstOrDefault(c => c.ID == id);
            if (crust is not null)
            {
                context.Remove(crust);
                context.SaveChanges();
                //context.ChangeTracker.Clear();
            }
        }

        public Domain.Abstracts.ACrust Update(Domain.Abstracts.ACrust updated)
        {            
            // this will create a new crust entity
            // with the proper ID and attach it so it is being tracked
            // then it will change it's fields
            Entities.Crust mappedCrust = mapper.Map(updated, context, true);
            context.SaveChanges();
            //context.ChangeTracker.Clear();
            return mapper.Map(mappedCrust);
        }
    }
}
