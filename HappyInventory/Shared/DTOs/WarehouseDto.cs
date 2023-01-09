using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyInventory.Shared.DTOs
{
    public class WarehouseDto
    {
        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
    }
}
