using OnlineStoreApplication.Entities;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public interface ICustomerUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IAddressRepository Addresses { get; }
    }
}
