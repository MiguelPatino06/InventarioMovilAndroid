using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TShirt.Inventory.App.Models
{
    public class CountPlan
    {
        [JsonConstructor]
        public CountPlan()
        {


        }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "DateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty(PropertyName = "Warehouse")]
        public string Warehouse { get; set; }

        [JsonProperty(PropertyName = "Value2")]
        public string Value2 { get; set; }

        [JsonProperty(PropertyName = "Value3")]
        public string Value3 { get; set; }

        [JsonProperty(PropertyName = "Value4")]
        public string Value4 { get; set; }

        [JsonProperty(PropertyName = "Value5")]
        public string Value5 { get; set; }

        [JsonProperty(PropertyName = "UserUpdated")]
        public string UserUpdated { get; set; }

        [JsonProperty(PropertyName = "DateUpdated")]
        public string DateUpdated { get; set; }

        [JsonProperty(PropertyName = "Details")]
        public List<CountPlanDetail> Details { get; set; }
    }
}
