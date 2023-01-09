using HappyInventory.Server.Service.AuthorizeService;
using HappyInventory.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyInventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService authorizeService;
        public AuthorizeController(IAuthorizeService authorizeService) 
        {
            this.authorizeService = authorizeService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginModel loginModel)
        {
           var response =  await authorizeService.Login(loginModel.Email,loginModel.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
