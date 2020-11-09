using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.v1_0
{
    public class Product
    {
        /// <summary>
        /// Product object description
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        public Product(Guid id, string name, string category)
        {
            Id = id;
            Name = name;
            Category = category;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; }
    }
}
