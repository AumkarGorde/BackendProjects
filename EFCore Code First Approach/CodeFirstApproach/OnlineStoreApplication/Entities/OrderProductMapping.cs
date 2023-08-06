using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class OrderProductMapping
    {
        public int OrderProductMappingID { get; set; } // Unique identifier for each order item.
        public int OrderID { get; set; } // References the order to which the item belongs
        public int ProductID { get; set; } // References the product associated with the item.
        public int Quantity { get; set; } // The quantity of the product ordered.

        public Order Order { get; set; } // It represents a many-to-one relationship between OrderProductMappings and Order. Each order item belongs to one order.
        public Product Product { get; set; } // It represents a many-to-one relationship between OrderProductMappings and Product. Each order item is associated with one product.
    }

}
