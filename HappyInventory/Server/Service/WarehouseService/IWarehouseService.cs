using HappyInventory.Shared;
using HappyInventory.Shared.DTOs;

namespace HappyInventory.Server.Service.WarehouseService
{
    public interface IWarehouseService
    {
        Task<ServiceResponse<Warehouse>> AddWarehouse(Warehouse warehouse);
        Task<ServiceResponse<Warehouse>> UpdateWarehouse(Warehouse warehouse);
        Task<ServiceResponse<Warehouse>> DeleteWarehouse(int id);
        Task<ServiceResponse<List<Role>>> GetRolesAsync();
        Task<ServiceResponse<WarehouseDto>> GetWarehousesAsync(int pageNumber, int pageSize);
        Task<ServiceResponse<List<Country>>> GetCountries();
    }
}
