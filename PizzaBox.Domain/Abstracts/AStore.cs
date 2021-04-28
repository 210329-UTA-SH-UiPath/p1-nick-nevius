using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Abstracts
{
    public enum STORE_TYPE
    {
        Unknown = 0,
        NewYork,
        Chicago
    }
    public abstract class AStore
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public STORE_TYPE StoreType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected AStore()
        {
            ID = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
