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
    [Route("api/category")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
           _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result =  await _service.GetAllCategory();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetCategoryById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDTO category)
        {
            try
            {
                var result = await _service.AddCategory(category);
                return CreatedAtAction(nameof(GetById), new { id = result.CategoryID }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /* Input with varoius operation
       [
           { "op": "replace", "path": "/Name", "value": "New Product Name" },
           { "op": "add", "path": "/Price", "value": 19.99 }
       ]
       */
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, JsonPatchDocument<Category> patchCategory)
        {
            try
            {
                await _service.UpdateCategoryById(id, patchCategory);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            try
            {
                await _service.DeleteCategoryById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
