using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; } //Unique identifier for each customer.
        public string FirstName { get; set; } //First name of the customer.
        public string LastName { get; set; } //Last name of the customer.
        public string Email { get; set; } //Email address of the customer.
        public string Phone { get; set; } //Phone number of the customer.
        public int AddressID { get; set; } // foreign key property linking address table.
        public Address Address { get; set; } // one-to-one mapping with customer table.
        public ICollection<Order> Orders { get; set; } //navigation property represents a one-to-many relationship between the Customer entity and the Order entity.
    }

    /*In this context:
     1. Customer is the "one" side of the relationship. A single Customer entity can be associated with multiple Order entities.
     2. Order is the "many" side of the relationship. Multiple Order entities can be associated with a single Customer entity.
     
    The ICollection<Order> navigation property provides a way to navigate from a Customer entity to its related Order entities. 
    Entity Framework Core will use this navigation property to establish the relationship between the entities and generate the appropriate database schema and foreign key constraints.
    */
}
