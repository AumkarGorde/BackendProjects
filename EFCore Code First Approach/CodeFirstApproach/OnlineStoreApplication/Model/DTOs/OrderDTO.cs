using System;

namespace OnlineStoreApplication.Model
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; } 
        public Guid CustomerId { get; set; }
    }
}
