using HappyInventory.Shared;

namespace HappyInventory.Client.Service.WarehouseService
{
    public interface IWarehouseService
    {
        List<Warehouse> Warehouses { get; set; }
        int TotalWarehouses { get; set; }
        int CurrentPage { get; set; }
        public List<Country> Countries { get; set; }
        Task GetWarehousesAsync(int page, int pageSize);
        Task GetCountries();
    }
}
