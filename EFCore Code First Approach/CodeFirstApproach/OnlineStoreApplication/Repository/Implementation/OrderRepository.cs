using OnlineStoreApplication.DataAccess;
using OnlineStoreApplication.Entities;

namespace OnlineStoreApplication.Repository
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        public OrderRepository(OnlineStoreDBContext context) : base(context)
        {
            
        }
    }
}
