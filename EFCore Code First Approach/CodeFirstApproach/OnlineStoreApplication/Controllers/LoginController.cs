using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApplication.Model;
using OnlineStoreApplication.Service;
using System;
using System.Threading.Tasks;

namespace OnlineStoreApplication.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ICustomerService _service;
        IAuthService _authService;
        public LoginController(ICustomerService service, IAuthService authService)
        {
            _service = service;
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginData data)
        {
            try
            {
                var result = await _service.ValidateCustomer(data);
                if(result is not null) 
                {
                    //TODO: Generate token
                    string token = _authService.GetJWTToken(result.UserName, result.Role);
                    if(token == null)
                    {
                        return Unauthorized();
                    }
                    return Ok(token);
                }
                else 
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
               return Unauthorized();
            }
        }
    }
}
