using HappyInventory.Shared;
using Microsoft.EntityFrameworkCore;

namespace HappyInventory.Server.Service.Dashboard
{
    public class Dashboard : IDashboard
    {
        private readonly DataContext _context;
        public Dashboard(DataContext context)
        {
            _context= context;
        }
        public async Task<ServiceResponse<List<Item>>> GetLow10Items()
        {
            var response = new ServiceResponse<List<Item>>
            {
                Data = await _context.Items.OrderBy(e => e.Qty).Take(10).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Item>>> GetTop10Items()
        {
            var response = new ServiceResponse<List<Item>>
            {
                Data = await _context.Items.OrderByDescending(e => e.Qty).Take(10).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Warehouse>>> GetWarehouses()
        {
            var response = new ServiceResponse<List<Warehouse>>
            {
                Data = await _context.Warehouse.ToListAsync()
            };

            return response;
        }
    }
}
