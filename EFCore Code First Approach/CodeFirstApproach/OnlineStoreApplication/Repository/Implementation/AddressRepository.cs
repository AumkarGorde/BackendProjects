using OnlineStoreApplication.DataAccess;
using OnlineStoreApplication.Entities;

namespace OnlineStoreApplication.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(OnlineStoreDBContext context) : base(context)
        {
            
        }
    }
}
