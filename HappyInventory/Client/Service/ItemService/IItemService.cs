namespace HappyInventory.Client.Service.ItemService
{
    public interface IItemService
    {
        List<Item> Items { get; set; }
        Task GetWarehouseItemsAsync(int id);
    }
}
