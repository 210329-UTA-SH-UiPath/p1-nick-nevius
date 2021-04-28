using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Client.Models
{
    public enum STORE_TYPE
    {
        Unknown = 0,
        NewYork,
        Chicago
    }
    public class Store
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public STORE_TYPE StoreType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Store()
        {
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
