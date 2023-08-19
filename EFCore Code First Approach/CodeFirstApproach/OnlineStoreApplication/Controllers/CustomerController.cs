using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineStoreApplication.Entities;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Service;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [Authorize(Roles ="ADMIN")]
    public class CustomerController : ControllerBase
    {
        ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAllCustomersWithAddress();

                if (response == null)
                    return NotFound();
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _service.GetCustomerById(id);

                if (response == null)
                    return NotFound();
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerDTO customerDTO)
        {
            try
            {
                var result = await _service.AddCustomerWithAddress(customerDTO);
                return CreatedAtAction(nameof(GetById), new { id = result }, customerDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(Guid id, CustomerDTO customerDTO)
        {
            try
            {
                await _service.UpdateCustomerById(id, customerDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /* Input with varoius operation
        [
            { "op": "replace", "path": "/Name", "value": "New Product Name" },
            { "op": "add", "path": "/Price", "value": 19.99 }
        ]
        */

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateCustomer(Guid id, JsonPatchDocument<Customer> patchDocument)
        {
            try
            {

                await _service.UpdateCustomerById(id, patchDocument);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            try
            {

                await _service.DeleteCustomerById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
