using HappyInventory.Shared;

namespace HappyInventory.Server.Service.Dashboard
{
    public interface IDashboard
    {
        Task<ServiceResponse<List<Item>>> GetTop10Items();
        Task<ServiceResponse<List<Item>>> GetLow10Items();
        Task<ServiceResponse<List<Warehouse>>> GetWarehouses();
    }
}
