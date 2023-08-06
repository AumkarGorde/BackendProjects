using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class Category
    {
        public int CategoryID { get; set; } //Unique identifier for each category.
        public string Name { get; set; } //The name of the category.
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }

}
