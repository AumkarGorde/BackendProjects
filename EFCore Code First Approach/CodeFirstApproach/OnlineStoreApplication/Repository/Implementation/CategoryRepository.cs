using OnlineStoreApplication.DataAccess;
using OnlineStoreApplication.Entities;

namespace OnlineStoreApplication.Repository
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineStoreDBContext context):base(context)
        {
            
        }
    }
}
