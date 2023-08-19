using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Service;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Controllers
{
    [Route("api/order/product")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class OrderProductController : ControllerBase
    {
        IOrderProductService _service;
        public OrderProductController(IOrderProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> MapOrderProduct(OrderProductMapDTO orderProduct)
        {
            try
            {
                await _service.MapOrderProducts(orderProduct);
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
    }
}
