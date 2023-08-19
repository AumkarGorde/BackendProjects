using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomersWithAddress();
        Task<CustomerDTO> GetCustomerById(Guid id);
        Task<Guid> AddCustomerWithAddress(CustomerDTO customerDTO);
        Task UpdateCustomerById(Guid id, CustomerDTO customerDTO);
        Task UpdateCustomerById(Guid id, JsonPatchDocument<Customer> patchDocument);
        Task DeleteCustomerById(Guid id);
        Task<Customer> ValidateCustomer(LoginData data);
    }
}
