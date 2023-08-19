using Microsoft.AspNetCore.JsonPatch;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProducts();
        Task<ProductResponseDTO> GetProductById(Guid id);
        Task<ProductResponseDTO> AddProduct(ProductDTO productDTO);
        Task UpdateProductById(Guid id, JsonPatchDocument<Product> patchDocument);
        Task DeleteProductById(Guid id);
    }
}
