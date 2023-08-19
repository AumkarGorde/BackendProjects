using OnlineStoreApplication.Entities;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public interface IProductCatgoryRepository:IRepository<ProductCategory>
    {
        Task<ProductCategory> GetProductCategory(Guid categoryId, Guid productId);
    }
}
