using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShirt.Inventory.App.Models
{
    public class ProductToTransfer
    {
        public long quantity { get; set; }
        public long quantityAvailable { get; set; }
        public string productCode { get; set; }
        public string productDescription { get; set; }
    }
}
