using AutoMapper;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;

namespace OnlineStoreApplication.DataAccess
{
    public class AutoMapperProfiles : Profile
    {
        /// <summary>
        /// Constructor having mapping configurations
        /// </summary>
        public AutoMapperProfiles() 
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));  //If property names are different use this technique
            CreateMap<CustomerDTO, Customer>()
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<CategoryResponseDTO, Category>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductResponseDTO>();
            CreateMap<ProductResponseDTO, Product>();

            CreateMap<ProductCategoryDTO, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryDTO>();

            CreateMap<OrderDTO, Order>()
                .ForMember(d => d.CustomerID, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(d => d.OrderID, opt => opt.MapFrom(s => s.OrderId))
            .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate));
            CreateMap<Order, OrderDTO>()
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerID))
                .ForMember(d => d.OrderId, opt => opt.MapFrom(s => s.OrderID))
                .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate));
        }
    }
}
