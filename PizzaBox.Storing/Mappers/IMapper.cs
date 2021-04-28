using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Storing.Mappers
{
    public interface IMapper<Database, Domain>
    {
        Domain Map(Database model);
        Database Map(Domain model, Entities.PizzaBoxDbContext context, bool update = false);
    }
}
