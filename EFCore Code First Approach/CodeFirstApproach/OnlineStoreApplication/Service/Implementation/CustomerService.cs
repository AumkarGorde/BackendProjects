using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerUnitOfWork _customerUnitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerUnitOfWork customerUnitOfWork, IMapper mapper)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddCustomerWithAddress(CustomerDTO customerDTO)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                customer.UserName = $"{customer.FirstName.ToLower()[0]}{customer.LastName.ToLower()}";
                customer.Role = "USER";
                await _customerUnitOfWork.Customers.AddAsync(customer);
                await _customerUnitOfWork.Customers.SaveChanges();
                customer.AddressID = customer.Address.AddressID;
                await _customerUnitOfWork.Customers.SaveChanges();

                return customer.CustomerID;
            }
            catch (Exception)
            {
                throw new Exception("Unable to create a new customer");
            }
        }

        public async Task DeleteCustomerById(Guid id)
        {
            try
            {
                var cus = await _customerUnitOfWork.Customers.GetByIdAsync(id);

                if (cus != null)
                {
                    // Delete the associated addresses, if applicable
                    if (cus.AddressID.HasValue)
                    {
                        var address = await _customerUnitOfWork.Addresses.GetByIdAsync(cus.AddressID.Value);
                        if (address != null)
                        {
                            _customerUnitOfWork.Addresses.Delete(address);
                        }
                    }

                    // Delete the customer
                    _customerUnitOfWork.Customers.Delete(cus);

                    await _customerUnitOfWork.Customers.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new Exception("Error while deleteing");
            }
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersWithAddress()
        {
            try
            {
                var result = await _customerUnitOfWork.Customers.GetAllCustomerWithAddress();
                var customersDto = _mapper.Map<IEnumerable<CustomerDTO>>(result);
                return customersDto;
            }
            catch (Exception)
            {

                throw new Exception("Error getting customer data");
            }

        }

        public async Task<CustomerDTO> GetCustomerById(Guid id)
        {
            try
            {
                var result = await _customerUnitOfWork.Customers.GetCustomerById(id);
                var customerDto = _mapper.Map<CustomerDTO>(result);
                return customerDto;
            }
            catch (Exception)
            {
                throw new Exception("Error getting customer data");
            }
        }

        public async Task UpdateCustomerById(Guid id, CustomerDTO customerDTO)
        {
            try
            {
                var cus = await _customerUnitOfWork.Customers.GetCustomerById(id);
                cus.Phone = customerDTO.Phone;
                cus.Email = customerDTO.Email;
                cus.FirstName = customerDTO.FirstName;
                cus.LastName = customerDTO.LastName;
                cus.Address.State = customerDTO.Address.State;
                cus.Address.City = customerDTO.Address.City;
                _customerUnitOfWork.Customers.Update(cus);
                await _customerUnitOfWork.Customers.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCustomerById(Guid id, JsonPatchDocument<Customer> patchDocument)
        {
            try
            {
                var cus = await _customerUnitOfWork.Customers.GetCustomerById(id);
                patchDocument.ApplyTo(cus);
                _customerUnitOfWork.Customers.Update(cus);
                await _customerUnitOfWork.Customers.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            };
        }

        public async Task<Customer> ValidateCustomer(LoginData data)
        {
            try
            {
                var cus = await _customerUnitOfWork.Customers.ValidateCustomer(data);
                if (cus != null)
                {
                    if (cus.Password == data.Password)
                    {
                        return cus;
                    }
                    else 
                    { 
                        return null; 
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
