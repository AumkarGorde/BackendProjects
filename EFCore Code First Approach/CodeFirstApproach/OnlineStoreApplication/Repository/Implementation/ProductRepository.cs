using OnlineStoreApplication.DataAccess;
using OnlineStoreApplication.Entities;

namespace OnlineStoreApplication.Repository
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(OnlineStoreDBContext context) : base(context)
        {
            
        }
    }
}
