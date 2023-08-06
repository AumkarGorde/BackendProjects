using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class Product
    {
        public int ProductID { get; set; } //(Primary Key, Auto-increment): Unique identifier for each product.
        public string Name { get; set; } //The name of the product.
        public string Description { get; set; } //A brief description of the product.
        public decimal Price { get; set; } //The price of the product.
        public ICollection<ProductCategory> ProductCategories { get; set; } // many-to-many relationship - one product can be in 2 categories. Eg: "Laptop" product might belong to both the "Electronics" and "Computers" categories
        public ICollection<OrderProductMappings> OrderProductMappings { get; set; } // one product can be multple orders - one-to-many
    }

}
