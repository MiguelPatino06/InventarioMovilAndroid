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
    public partial class ProductDetail : ContentPage
    {
        public ProductDetail(OrderDetailExtend details)
        {
            InitializeComponent();
            BindingContext = new OrderDetailViewModel(details);
        }


        //void OnButtonClicked(object sender, EventArgs args)
        //{

        //    EnteredName.Text = string.Empty;

        //    overlay.IsVisible = true;

        //    EnteredName.Focus();
        //}

        //private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        //{
        //    EnteredName.Text = string.Empty;
        //    overlay.IsVisible = true;
        //    EnteredName.Focus();
        //}

        private void OnTapGestureRecognizerTapped2(object sender, EventArgs e)
        {

            OrderDetailViewModel mvm = sender as OrderDetailViewModel;


            var arrayCodes = ((OrderDetailViewModel)BindingContext).OrderProduct;

            var list = new List<OrderTShirt>();
            foreach (var item in arrayCodes)
            {
                list.Add(new OrderTShirt() { Code = item });
            }


            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new OrderPage(list, null));
        }

        //private void OnOKButtonClicked(object sender, EventArgs e)
        //{
        //    overlay.IsVisible = false;
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            EntrQuantity.Focus();
            EntrQuantity.Text = "";

        }
    }
}

   