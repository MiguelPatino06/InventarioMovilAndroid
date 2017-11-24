using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TShirt.Inventory.App.Models;
using TShirt.Inventory.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirt.Inventory.App.Pages.Recepcion
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {

        private List<OrderTShirt> _code { get; set; }
        private List<ViewOrder> _orders { get; set; }
        private int CountPage { get; set; }

        public OrderPage(List<OrderTShirt> codes, List<ViewOrder> orders)
        {
            CountPage = 0;
            _code = codes;
            _orders = orders;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
           
            base.OnAppearing();
            CountPage += 1;

            GetOrderPage();
            EntBarcode.Text = "";
            EntBarcode.Focus();
        }

        //private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        //{
        //    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Search());
        //}

        protected override bool OnBackButtonPressed()
        {
            return true; // Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }

        private void GetOrderPage()
        {
            this.BindingContext = CountPage == 1 ? new OrderViewModel(_code, _orders) : new OrderViewModel(_code, null);
        }
    }

  
}
