using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class OrderProductMapping
    {
        public Guid OrderProductMappingID { get; set; } // Unique identifier for each order item.
        public Guid OrderID { get; set; } // References the order to which the item belongs
        public Guid ProductID { get; set; } // References the product associated with the item.
        public int Quantity { get; set; } // The quantity of the product ordered.
        public Order Order { get; set; } // It represents a many-to-one relationship between OrderProductMappings and Order. Each order item belongs to one order.
        public Product Product { get; set; } // It represents a many-to-one relationship between OrderProductMappings and Product. Each order item is associated with one product.
    }

    /*
    It's common to use navigation properties of type `ICollection<T>` on both sides of the relationship. 
    However, when dealing with a junction table like `OrderProductMapping`, you usually don't need `ICollection<T>` on both sides.
    Here's why:
        1. Navigation from Order to Products**: 
                In a many-to-many relationship, you would typically navigate from an `Order` to its associated `Product`s using an `ICollection<Product>` navigation property. 
                However, in the context of the `OrderProductMapping` table, you're not directly navigating from an `Order` to its products. 
                Instead, you're using the `OrderProductMapping` table to establish the relationship and store additional information like the quantity. 
                Therefore, you don't need `ICollection<Product>` in the `Order` entity.
        2. Navigation from Product to Orders**: 
                Similarly, you don't need an `ICollection<Order>` navigation property in the `Product` entity. 
                Again, this is because the relationship is managed through the `OrderProductMapping` table, and you're not directly navigating from a `Product` to its orders.

    In the context of the `OrderProductMapping` table, the relationship between `Order` and `Product` is captured through the navigation properties `Order` and `Product` within 
    the `OrderProductMapping` entity itself. These properties allow you to navigate from an `OrderProductMapping` record to the associated `Order` and `Product`, 
    and the `Quantity` property provides additional context about the relationship.
    
    In summary, while `ICollection<T>` navigation properties are often used for many-to-many relationships, in cases where a junction table is involved, 
    you focus on the relationship properties within the junction table itself, rather than duplicating these relationships in the associated entities. 
    This simplifies the design and accurately reflects the structure of the database schema.
     */
}
