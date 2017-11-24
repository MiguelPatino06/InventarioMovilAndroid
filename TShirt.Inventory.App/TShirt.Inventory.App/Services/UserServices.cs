using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TShirt.Inventory.App.Models;
using TShirt.Inventory.App.Properties;

namespace TShirt.Inventory.App.Services
{
    public class UserServices
    {
        HttpClient client;
        private string PATHSERVER { get; set; }
        public User Item { get; private set; }

        public UserServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            PATHSERVER = Resources.PathServer;
        }

        public async Task<User> GetProviderName(string code, string pass)
        {
            Item = new User();
            string url = "http://" + PATHSERVER + "/tshirt/user/Getuser";
            string _code = "?code=" + code;
            string _pass = "&pass=" + pass;
            string uri = string.Concat(url, _code, _pass);

            try
            {
                var result = await client.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<User>(content);
                }
                else
                    Item = null;


            }
            catch (Exception ex)
            {
                // Item = null;
                Item.Name = ex.Message.ToString() + " Error Path 3" + PATHSERVER;
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Item;
        }

        public string GetPath()
        {
            return PATHSERVER;
        }


    }
}
