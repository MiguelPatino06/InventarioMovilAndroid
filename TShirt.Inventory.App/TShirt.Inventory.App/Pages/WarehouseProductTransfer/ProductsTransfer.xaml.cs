using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirt.Inventory.App.Pages.WarehouseProductTransfer
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsTransfer : ContentPage
    {
        public ProductsTransfer()
        {
            InitializeComponent();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Warehouses());
        }
    }

   
}
