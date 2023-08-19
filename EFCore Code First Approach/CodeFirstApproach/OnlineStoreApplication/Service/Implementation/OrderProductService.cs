using AutoMapper;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IMapper _mapper;
        private readonly IOrderProcductRepository _repository;
        public OrderProductService(IMapper mapper, IOrderProcductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task MapOrderProducts(OrderProductMapDTO orderProduct)
        {
            try
            {
                var listOfMappings = new List<OrderProductMapping>();
                foreach (var product in orderProduct.Products)
                {
                    var odrprdmp = new OrderProductMapping()
                    {
                         OrderID = orderProduct.OrderId,
                         ProductID = product.ProductID,
                         Quantity = product.Quatity
                    };
                    listOfMappings.Add(odrprdmp);
                }
                await _repository.AddRangeOrderProductMappings(listOfMappings);
            }
            catch (System.Exception)
            {
                throw new Exception("Cannot map order to products");
            }
        }
    }
}
