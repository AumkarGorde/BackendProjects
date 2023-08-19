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
    public class ProductService: IProductService
    {
        private readonly IMapper _mapper;
        IProductRepository _repository;
        public ProductService(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductResponseDTO> AddProduct(ProductDTO productDTO)
        {
            try
            {
                var prd = _mapper.Map<Product>(productDTO);
                await _repository.AddAsync(prd);
                await _repository.SaveChanges();
                return _mapper.Map<ProductResponseDTO>(prd);
            }
            catch (Exception)
            {
                throw new Exception("Cannot create Product");
            }
        }

        public async Task DeleteProductById(Guid id)
        {
            try
            {
                var prd = await _repository.GetByIdAsync(id);
                if (prd != null)
                {
                    _repository.Delete(prd);
                    await _repository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new Exception("Cannot delete product");
            }
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProducts()
        {
            try
            {
                var prds = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<ProductResponseDTO>>(prds);
            }
            catch (Exception)
            {
                throw new Exception("Cannot get product");
            }
        }

        public async Task<ProductResponseDTO> GetProductById(Guid id)
        {
            try
            {
                var prd = await _repository.GetByIdAsync(id);
                return _mapper.Map<ProductResponseDTO>(prd);
            }
            catch (Exception)
            {

                throw new Exception("");
            }
        }

        public async Task UpdateProductById(Guid id, JsonPatchDocument<Product> patchDocument)
        {
            try
            {
                var prd = await _repository.GetByIdAsync(id);
                patchDocument.ApplyTo(prd);
                _repository.Update(prd);
                await _repository.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("");
            }
        }
    }
}
