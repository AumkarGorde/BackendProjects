using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomerWithAddress();
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> ValidateCustomer(LoginData data);
    }
}
