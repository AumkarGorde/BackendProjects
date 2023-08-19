using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Model.Enum;
using OnlineStoreApplication.Service;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class ProductCatgoryController : ControllerBase
    {
        IProductCatgoryService _service;
        public ProductCatgoryController(IProductCatgoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllProductCategoryMappings();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> MapProductCategory(ProductCategoryDTO productCategory)
        {
            try
            {
                var result = await _service.AddProductCategoryMapping(productCategory);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("category/{oldId}")]
        public async Task<ActionResult> UpdateProductCategoryMappings(Guid oldId, ProductCategoryDTO productCategory)
        {
            try
            {
                await _service.UpdateMappingCategoryId(oldId, productCategory);
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
