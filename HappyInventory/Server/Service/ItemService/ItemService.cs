using HappyInventory.Server.Data;
using HappyInventory.Shared;
using Microsoft.EntityFrameworkCore;

namespace HappyInventory.Server.Service.ItemService
{
    public class ItemService : IItemService
    {

        private readonly DataContext _context;
        public ItemService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Item>>> GetItemsByWarehouseId(int warehouseId)
        {
            var response = new ServiceResponse<List<Item>>();
            var items = await _context.Items.Where(e => e.Warehouse.Id == warehouseId).ToListAsync();
            if(items == null)
            {
                response.Success= false;
                response.Message = "No Items...";
            }
            else
            {
                response.Data= items;
            }
            return response;
        }

    }
}
