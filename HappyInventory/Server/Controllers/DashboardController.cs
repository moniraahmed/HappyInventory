using HappyInventory.Server.Service.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyInventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _dashboard;
        public DashboardController(IDashboard dashboard) 
        { 
            _dashboard = dashboard;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopAvailableQuantity()
        {
            var result = await _dashboard.GetTop10Items();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLowAvailableQuantity()
        {
            var result = await _dashboard.GetLow10Items();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableWarehouse()
        {
            var result = await _dashboard.GetWarehouses();
            return Ok(result);
        }
    }
}
