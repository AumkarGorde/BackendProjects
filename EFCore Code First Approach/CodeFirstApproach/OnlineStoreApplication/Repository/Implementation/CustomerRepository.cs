using Microsoft.EntityFrameworkCore;
using OnlineStoreApplication.DataAccess;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Repository
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineStoreDBContext context):base(context) 
        {
        }

        /// <summary>
        /// Example of eager loading
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllCustomerWithAddress()
        {
            try
            {
                return await _entities.Include("Address")
                      .ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error getting customer details from database");
            }

        }
        /// <summary>
        /// Get Customer with Address with
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerById(Guid id)
        {
            try
            {
                return await _entities.Include(c => c.Address)
                             .FirstOrDefaultAsync(c => c.CustomerID == id);
            }
            catch (Exception)
            {
                throw new Exception("Error getting customer detail from database");
            }

        }

        public async Task<Customer> ValidateCustomer(LoginData data)
        {
            try
            {
                return await _entities.Where(c=>c.UserName == data.UserName).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error getting customer detail from database");
            }
        }
    }
}
