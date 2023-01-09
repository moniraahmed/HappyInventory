global using HappyInventory.Shared;
using HappyInventory.Shared.DTOs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace HappyInventory.Client.Service.WarehouseService
{
    public class WarehouseService : IWarehouseService
    {
        private readonly HttpClient httpClient;
        public WarehouseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        public int TotalWarehouses { get; set; }
        public int CurrentPage { get; set; }
        public Warehouse warehouse { get; set; } = new Warehouse();
        public List<Country> Countries { get; set; } = new List<Country>();
        public async Task GetWarehousesAsync(int page,int pageSize)
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<WarehouseDto>>($"api/Warehouse/warhouses/{page}/{pageSize}");
            if(result!= null && result.Data != null)
            {
                Warehouses = result.Data.Warehouses;
                TotalWarehouses = result.Data.TotalCount;
                CurrentPage = result.Data.CurrentPage;
            }
        }
        public async Task GetCountries()
        {
            var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<Country>>>($"api/Warehouse/countries");
            if (result != null && result.Data != null)
            {
                Countries = result.Data;
            }
        }
        public async Task AddWarehousesAsync(Warehouse warehouse)
        {
            var result = await httpClient.PostAsJsonAsync("api/warhouses/add", warehouse);
            //if (result != null && result.Data != null)
            //{
            //    Warehouses = result.Data.Warehouses;
            //    TotalWarehouses = result.Data.TotalCount;
            //    CurrentPage = result.Data.CurrentPage;
            //}
        }


    }
}
