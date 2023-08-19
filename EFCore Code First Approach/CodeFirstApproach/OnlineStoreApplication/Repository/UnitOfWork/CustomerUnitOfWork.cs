using OnlineStoreApplication.DataAccess;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public class CustomerUnitOfWork : ICustomerUnitOfWork
    {
        private readonly OnlineStoreDBContext _context;
        public CustomerUnitOfWork(OnlineStoreDBContext context, ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _context = context;
            Customers = customerRepository;
            Addresses = addressRepository;
        }

        public ICustomerRepository Customers { get; }

        public IAddressRepository Addresses { get; }
    }
}
