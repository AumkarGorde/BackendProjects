using OnlineStoreApplication.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public interface IOrderService
    {
        Task CreateOrder(Guid customerId);
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task DeleteOrder(Guid ordderId);
    }
}
