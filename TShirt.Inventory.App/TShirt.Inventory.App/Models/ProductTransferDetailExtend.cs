using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShirt.Inventory.App.Models
{
    public class ProductTransferDetailExtend
    {
        public ProductTransferDetailExtend() { }

        public long Quantity { get; set; }

        private string _productCode;
        public string ProductCode
        {
            get { return _productCode.Trim(); }
            set { _productCode = value; }
        }

        private string _productDescription;
        public string ProductDescription
        {
            get { return _productDescription.Trim(); }
            set { _productDescription = value; }
        }
    }
}
