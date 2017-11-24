using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TShirt.Inventory.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirt.Inventory.App.Pages.WarehouseProductTransfer
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Warehouses : ContentPage
    {
        public Warehouses()
        {
            InitializeComponent();
            BindingContext = new WarehouseProductTransferViewModel();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Menu());
        }
    }
}
