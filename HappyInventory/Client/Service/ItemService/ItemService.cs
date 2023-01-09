global using HappyInventory.Shared;
using System.Net.Http.Json;

namespace HappyInventory.Client.Service.ItemService
{
    public class ItemService : IItemService
    {
        private readonly HttpClient httpClient;
        public ItemService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public List<Item> Items { get; set; } = new List<Item>();

        public async Task GetWarehouseItemsAsync(int itemId)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<Item>>>($"api/Items/{itemId}");
            if (result != null && result.Data != null)
            {
                Items = result.Data;
            }
            //Items = new List<Item>
            //{
            //    new Item
            //    {
            //        Cost = 100,
            //        MSRPPrice = 120,
            //        Name="hhhhh",
            //        Qty = 10,
            //        SKUCode = "123"
            //    }
            //};
        }
    }
}
