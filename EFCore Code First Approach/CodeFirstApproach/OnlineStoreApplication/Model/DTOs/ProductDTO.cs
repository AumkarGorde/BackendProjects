using System;

namespace OnlineStoreApplication.Model
{
    public class ProductDTO
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductResponseDTO
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
