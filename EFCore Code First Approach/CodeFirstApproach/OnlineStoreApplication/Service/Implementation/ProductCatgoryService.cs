using AutoMapper;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Service
{
    public class ProductCatgoryService: IProductCatgoryService
    {
        private readonly IMapper _mapper;
        private readonly IProductCatgoryRepository _repository;
        public ProductCatgoryService(IMapper mapper, IProductCatgoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductCategoryDTO> AddProductCategoryMapping(ProductCategoryDTO productDTO)
        {
            try
            {
                var pcmp = _mapper.Map<ProductCategory>(productDTO);
                await _repository.AddAsync(pcmp);
                await _repository.SaveChanges();
                return _mapper.Map<ProductCategoryDTO>(pcmp);
            }
            catch (System.Exception)
            {
                throw new System.Exception("Cannot create mapping");
            }
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetAllProductCategoryMappings()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<ProductCategoryDTO>>(result);
            }
            catch (System.Exception)
            {
                throw new System.Exception("Cannot get mapping");
            }
        }

        public async Task UpdateMappingCategoryId(Guid oldCategoryId, ProductCategoryDTO productCategory)
        {
            try
            {
                var pcmp = await _repository.GetProductCategory(oldCategoryId, productCategory.ProductID);
                if (pcmp != null)
                {
                    _repository.Delete(pcmp);
                    await _repository.SaveChanges();
                    var newMapping = new ProductCategory(){
                         CategoryID = productCategory.CategoryID, 
                         ProductID = productCategory.ProductID
                    };
                    await _repository.AddAsync(newMapping);
                    await _repository.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot update categoryId, no mapping of such kind");
                }
            }
            catch (Exception)
            {
                throw new Exception("Cannot update categoryId");
            }
        }
    }
}
