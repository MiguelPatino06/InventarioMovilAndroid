using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShirt.Inventory.App.Models
{
    public class ProductTransfer
    {
        public int Id { get; set; }
        public string warehouseOrigin { get; set; }
        public string warehouseDestiny { get; set; }
        public List<ProductToTransfer> products { get; set; }
        public string dateCreated { get; set; }
        public string status { get; set; }
        public string observation { get; set; }
    }
}

