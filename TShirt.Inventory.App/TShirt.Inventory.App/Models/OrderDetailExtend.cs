using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShirt.Inventory.App.Models
{
    public class OrderDetailExtend
    {
        public string order { get; set; }
        public string providerName { get; set; }
        public string productBarcode { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public string providerCode { get; set; }
        public string[] codeOrders { get; set; }
        public string[] OrderProducts { get; set; }
    }
}
