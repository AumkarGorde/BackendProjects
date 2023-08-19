using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApplication.Service;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class OrderController : ControllerBase
    {
        IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllOrders();
                return Ok(result);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult> CreateOrder(Guid customerId)
        {
            try
            {
                await _service.CreateOrder(customerId);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(Guid orderId)
        {
            try
            {
                await _service.DeleteOrder(orderId);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
