using OnlineStoreApplication.Model;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public interface IOrderProductService
    {
        Task MapOrderProducts(OrderProductMapDTO orderProduct);
    }
}
