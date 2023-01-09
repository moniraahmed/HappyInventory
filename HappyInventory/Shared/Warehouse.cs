using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyInventory.Shared
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required] public string City { get; set; } = string.Empty;
        public Country Country { get; set; } = new Country();
        public List<Item> Items { get; set; } = new List<Item>();

    }
}
