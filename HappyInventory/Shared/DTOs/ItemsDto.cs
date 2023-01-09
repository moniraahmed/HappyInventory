using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyInventory.Shared.DTOs
{
    public class ItemsDto
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
