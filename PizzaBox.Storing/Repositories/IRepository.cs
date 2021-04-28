using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Storing.Repositories
{
    public interface IRepository<T>
    {
        void Add(T t);
        List<T> GetList();
        T GetById(int id);
        void Remove(int id);
        T Update(T updated);
    }
}
