using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class ProductCategory
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public ICollection<Product> Products { get; set; } // many-to-many relationship between product and category
        public ICollection<Category> Categories { get; set; } // many-to-many relationship between product and category
    }
}
