using OnlineStoreApplication.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public interface IOrderProcductRepository:IRepository<OrderProductMapping>
    {
        Task AddRangeOrderProductMappings(List<OrderProductMapping> orderProductMappings);
    }
}
