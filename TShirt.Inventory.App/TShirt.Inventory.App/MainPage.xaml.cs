using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirt.Inventory.App.Models;
using TShirt.Inventory.App.Services;
using Xamarin.Forms;

namespace TShirt.Inventory.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadData();

        }

        public async void LoadData()
        {
            CountServices services = new CountServices();
            var result = await services.GetAll();

            List<Test> list = new List<Test>();

            list.Add(new Test()
            {
                Id = 1,
                Value1 = "uno",
                Value2 = "Dos"
            });

            list.Add(new Test()
            {
                Id = 2,
                Value1 = "tres",
                Value2 = "cuatro"
            });



        }

      
    }
}
