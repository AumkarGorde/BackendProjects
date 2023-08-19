using System;

namespace OnlineStoreApplication.Model
{
    public class CategoryDTO
    {
        public string Name { get; set; }
    }

    public class CategoryResponseDTO
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
    }
}
