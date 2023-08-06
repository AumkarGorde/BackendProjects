using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class Order
    {
        public int OrderID { get; set; } //Unique identifier for each order.
        public DateTime OrderDate { get; set; } //Date when the order was placed.

        public int CustomerID { get; set; } //It is a foreign key property that references the primary key (CustomerID) of the Customer entity.
        public Customer Customer { get; set; } //  navigation property - each order is placed by a single customer

        public ICollection<OrderProductMapping> OrderItems { get; set; } // one-to-many relationship, where an order can have multiple order items i.e prodducts.
    }

}
