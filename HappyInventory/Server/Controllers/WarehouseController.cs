using HappyInventory.Server.Service.WarehouseService;
using HappyInventory.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HappyInventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;
       
        public WarehouseController(IWarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }
        
        [HttpGet]
        [Route("warhouses/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetWarehousesAsync(int pageNumber = 1, int pageSize = 10)
        {
            var result = await warehouseService.GetWarehousesAsync(pageNumber,pageSize);
            return Ok(result);
        }

        [HttpPost]
        [Route("warhouses/add")]
        public async Task<IActionResult> AddWarehouseAsync([FromBody] Warehouse warehouse)
        {
            var result = await warehouseService.AddWarehouse(warehouse);
            return Ok(result);
        }
        [HttpPost]
        [Route("warhouses/update")]
        public async Task<IActionResult> UpdateWarehouseAsync([FromBody] Warehouse warehouse)
        {
            var result = await warehouseService.UpdateWarehouse(warehouse);
            return Ok(result);
        }
        [HttpPost]
        [Route("warhouses/delete")]
        public async Task<IActionResult> DeleteWarehouseAsync(int Id)
        {
            var result = await warehouseService.DeleteWarehouse(Id);
            return Ok(result);
        }

        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetRolesAsync()
        {
            var result = await warehouseService.GetRolesAsync();
            return Ok(result);
        }
    }
}
