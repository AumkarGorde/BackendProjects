using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class ProductCategory
    {
        public Guid ProductID { get; set; }
        public Guid CategoryID { get; set; }
        public Product Product { get; set; } // many-to-many relationship between product and category
        public Category Category { get; set; } // many-to-many relationship between product and category
    }
}
