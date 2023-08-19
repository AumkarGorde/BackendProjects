using Microsoft.EntityFrameworkCore;
using OnlineStoreApplication.DataAccess;
using OnlineStoreApplication.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public class ProductCatgoryRepository : Repository<ProductCategory>, IProductCatgoryRepository
    {
        public ProductCatgoryRepository(OnlineStoreDBContext context) : base(context)
        {
        }

        public async Task<ProductCategory> GetProductCategory(Guid categoryId, Guid productId)
        {
            try
            {
                var result = await _entities.FirstOrDefaultAsync
                                            (m => m.ProductID == productId && m.CategoryID == categoryId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
