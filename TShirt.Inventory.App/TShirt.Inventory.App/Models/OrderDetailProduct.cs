﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShirt.Inventory.App.Models
{
    public class OrderDetailProduct
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public string UserCode { get; set; }
        public string DateCreated { get; set; }
        public int Quantity { get; set; }
        public string ProductCode { get; set; }
        public string ProviderCode { get; set; }
        public string FullDescription {
            get { return OrderCode + " " + UserCode + " " + DateCreated; }

        }
    }
}
