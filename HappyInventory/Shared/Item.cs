using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyInventory.Shared
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string SKUCode { get; set; } = string.Empty;

        [MinLength(1)]
        public int Qty { get; set; }

        [Required]
        public decimal Cost { get; set; }
        public decimal MSRPPrice { get; set; }

        [Required]
        public Warehouse Warehouse { get; set; } = new Warehouse();


    }
}
