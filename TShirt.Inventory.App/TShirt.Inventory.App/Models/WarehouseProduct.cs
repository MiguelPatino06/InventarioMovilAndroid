using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShirt.Inventory.App.Models
{
    public class WarehouseProduct
    {
        public int Id { get; set; }
        public string WarehouseCode { get; set; }
        public string ProductCode { get; set; }
        public long Quantity { get; set; }
        public Warehouse Warehouse { get; set; }
        public Product Product { get; set; }
    }
}
