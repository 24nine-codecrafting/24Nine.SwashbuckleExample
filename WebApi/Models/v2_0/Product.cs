using System;
using System.Security.Cryptography.X509Certificates;
using WebApi.Models.v2_0.Enums;

namespace WebApi.Models.v2_0
{
    /// <summary>
    /// Version 2.0 of the product
    /// Changes: Added shop location to the object
    /// </summary>
    public class Product
    {
        public Product(Guid id, string name, string category, ShopLocation storeLocation)
        {
            Id = id;
            Name = name;
            Category = category;
            StoreLocation = storeLocation;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; }
        public ShopLocation StoreLocation { get; }
    }
}
