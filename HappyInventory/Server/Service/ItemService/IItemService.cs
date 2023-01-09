using HappyInventory.Shared;

namespace HappyInventory.Server.Service.ItemService
{
    public interface IItemService
    {
        Task<ServiceResponse<List<Item>>> GetItemsByWarehouseId(int warehouseId);
    }
}
