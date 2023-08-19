using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Entities
{
    public class Address
    {
        [Key]
        public Guid AddressID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
    }

}
