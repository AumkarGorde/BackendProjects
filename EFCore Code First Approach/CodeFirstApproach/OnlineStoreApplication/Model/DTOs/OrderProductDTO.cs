using System;
using System.Collections.Generic;

namespace OnlineStoreApplication.Model
{
    public class OrderProductMapDTO
    {
        public Guid OrderId { get; set; }
        public List<OrderProductDTO> Products { get; set; }
    }

    public class OrderProductDTO
    {
        public Guid ProductID { get; set; }
        public int Quatity { get; set; }

    }
}
