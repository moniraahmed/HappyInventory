using HappyInventory.Server.Data;
using HappyInventory.Shared;
using HappyInventory.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HappyInventory.Server.Service.WarehouseService
{
    public class WarehouseService : IWarehouseService
    {
        private readonly DataContext _context;
        public WarehouseService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Warehouse>> AddWarehouse(Warehouse warehouse)
        {
            var response = new ServiceResponse<Warehouse>();
            _context.Warehouse.Add(warehouse);
            await _context.SaveChangesAsync();
            response.Data= warehouse;
            return response;

        }

        public async Task<ServiceResponse<Warehouse>> DeleteWarehouse(int id)
        {
            var response = new ServiceResponse<Warehouse>();

            var warehouse = await _context.Warehouse.FindAsync(id);
            if(warehouse != null)
                 _context.Warehouse.Remove(warehouse);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<ServiceResponse<List<Country>>> GetCountries()
        {
            var response = new ServiceResponse<List<Country>>
            {
                Data = await _context.Countries.ToListAsync()
            };

            return response;
            
        }

        public async Task<ServiceResponse<List<Role>>> GetRolesAsync()
        {
            var response = new ServiceResponse<List<Role>>
            {
                Data = await _context.Roles.ToListAsync()
        };
           
            return response;
        }

        public async Task<ServiceResponse<WarehouseDto>> GetWarehousesAsync(int pageNumber, int pageSize)
        {
            var response = new ServiceResponse<WarehouseDto>();

            var warehouses = _context.Warehouse.Include(e => e.Country).AsQueryable();
      
            var totalCount = warehouses.Count();

            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;

            var res = await warehouses.OrderByDescending(o => o.Id).Skip(skip).Take(take).Select(x=>x).ToListAsync();
            var warehousesDto = new WarehouseDto
            {
                TotalCount= totalCount,
                Warehouses = res
            };
            response.Data = warehousesDto;
            return response;

        }

        public async Task<ServiceResponse<Warehouse>> UpdateWarehouse(Warehouse warehouse)
        {
            var response = new ServiceResponse<Warehouse>();
            var oldWarehouse = await _context.Warehouse.Where(e=>e.Id == warehouse.Id).FirstOrDefaultAsync();
            if (warehouse != null)
                _context.Warehouse.Update(warehouse);
            await _context.SaveChangesAsync();

            response.Data = warehouse;
            return response;
        }
    }
}
