using Microsoft.AspNetCore.JsonPatch;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDTO>> GetAllCategory();
        Task<CategoryResponseDTO> GetCategoryById(Guid id);
        Task<CategoryResponseDTO> AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategoryById(Guid id, JsonPatchDocument<Category> patchDocument);
        Task DeleteCategoryById(Guid id);
    }
}
