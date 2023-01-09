using HappyInventory.Server.Service.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyInventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemsController : ControllerBase
    {
         private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetItemsByWarehouseId(int Id)
        {
            var result = await _itemService.GetItemsByWarehouseId(Id);
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);

        }
    }
}
