using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }

}
