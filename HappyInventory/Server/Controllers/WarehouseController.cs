using HappyInventory.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace HappyInventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly DataContext _context;
        public WarehouseController(DataContext context)
        {
            _context = context;
        }
        
        private static List<Warehouse> warehouses = new List<Warehouse>
        {
           new Warehouse
           {
            Name = "warehouse1",
            Address = "hhhhh",
            City="cairo",
            Country= new Country{ Id = 1 ,Name = "Egypt"},
            Items = new List<Item>
            {
                new Item
                {
                    Name = "item1",
                    Cost =100,
                    Qty = 2,
                    MSRPPrice = 22,
                    SKUCode = "i22"
                }
            }
           }
        };

        [HttpGet]
        [Route("warhouses")]
        public async Task<IActionResult> GetWarehousesAsync()
        {
            return Ok(warehouses);
        }

        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetRolesAsync()
        {
           
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }
    }
}
