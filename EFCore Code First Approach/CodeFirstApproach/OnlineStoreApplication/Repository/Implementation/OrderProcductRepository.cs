using OnlineStoreApplication.DataAccess;
using OnlineStoreApplication.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public class OrderProcductRepository : Repository<OrderProductMapping>, IOrderProcductRepository
    {
        public OrderProcductRepository(OnlineStoreDBContext context) : base(context)
        {
            
        }

        public async Task AddRangeOrderProductMappings(List<OrderProductMapping> orderProductMappings)
        {
            try
            {
                await _entities.AddRangeAsync(orderProductMappings);
                await SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
