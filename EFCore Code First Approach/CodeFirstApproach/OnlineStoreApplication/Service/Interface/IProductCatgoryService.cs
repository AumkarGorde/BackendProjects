using Microsoft.AspNetCore.JsonPatch;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public interface IProductCatgoryService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetAllProductCategoryMappings();
        Task<ProductCategoryDTO> AddProductCategoryMapping(ProductCategoryDTO productDTO);
        Task UpdateMappingCategoryId(Guid oldCategoryId, ProductCategoryDTO productCategory);
    }
}
