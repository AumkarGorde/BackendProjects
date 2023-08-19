using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Service;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "RequireAdminOrUser")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllProducts();
                return Ok(result);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult> GetProductById(Guid id)
        {
            try
            {
                var result = await _service.GetProductById(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> CreateProduct(ProductDTO product)
        {
            try
            {
                var result = await _service.AddProduct(product);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> UpdateProduct(Guid id, JsonPatchDocument<Product> patchDocument)
        {
            try
            {
                await _service.UpdateProductById(id, patchDocument);
                return NoContent();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _service.DeleteProductById(id);
                return NoContent();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
    }
}
