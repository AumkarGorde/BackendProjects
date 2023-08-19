using AutoMapper;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;
        public OrderService(IMapper mapper, IOrderRepository repository)
        {
            _mapper = mapper;   
            _repository = repository;
        }

        public async Task CreateOrder(Guid customerId)
        {
            try
            {
                var order = new Order()
                {
                     CustomerID = customerId,
                     OrderDate = DateTime.Now,
                };
                await _repository.AddAsync(order);
                await _repository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Cannot create order");
            }
        }

        public async Task DeleteOrder(Guid orderId)
        {
            try
            {
                var odr = await _repository.GetByIdAsync(orderId);
                if(odr != null)
                {
                    _repository.Delete(odr);
                    await _repository.SaveChanges();
                }                
            }
            catch (Exception)
            {

                throw new Exception("Cannot delete order");
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<OrderDTO>>(result);
            }
            catch (Exception)
            {

                throw new Exception("Cannot get order");
            }
        }
    }
}
