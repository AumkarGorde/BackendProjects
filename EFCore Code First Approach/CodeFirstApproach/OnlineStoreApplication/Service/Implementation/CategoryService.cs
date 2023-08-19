using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryResponseDTO> AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                await  _categoryRepository.AddAsync(category);
                await _categoryRepository.SaveChanges();
                return _mapper.Map<CategoryResponseDTO>(category);
            }
            catch (Exception)
            {
                throw new Exception("Cannot add category");
            }
        }

        public async Task DeleteCategoryById(Guid id)
        {
            try
            {
                var caty = await _categoryRepository.GetByIdAsync(id);
                if(caty != null)
                {
                    _categoryRepository.Delete(caty);
                    await _categoryRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Cannot delete category");
            }
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllCategory()
        {
            try
            {
                var result = await _categoryRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<CategoryResponseDTO>>(result);
            }
            catch (Exception)
            {
                throw new Exception("Cannot get category");
            }
        }

        public async Task<CategoryResponseDTO> GetCategoryById(Guid id)
        {
            try
            {
                var result = await _categoryRepository.GetByIdAsync(id);
                return _mapper.Map<CategoryResponseDTO>(result);
            }
            catch (Exception)
            {
                throw new Exception("Cannot get category");
            }
        }

        public async Task UpdateCategoryById(Guid id, JsonPatchDocument<Category> patchDocument)
        {
            try
            {
                var caty = await _categoryRepository.GetByIdAsync(id);
                patchDocument.ApplyTo(caty);
                _categoryRepository.Update(caty);
                await _categoryRepository.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Cannot update category");
            }
        }
    }
}
