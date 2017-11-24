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

//using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace TShirt.Inventory.App.Pages.Count
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Plan : ContentPage
    {
        public int _id { get; set; }
        public Plan(int id)
        {
            _id = id;
            InitializeComponent();
            //BindingContext = new CountViewModel(id);

        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();

            GetPlan();
            EntBarcode.Text = "";
            EntBarcode.Focus();

        }

        private void GetPlan()
        {
            BindingContext = new CountViewModel(_id);
        }

        // OnTapPrevPage
        ////private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        ////{
        ////    Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        ////}


        private void OnTapPrevPage(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }

        private void OnTapNextPage(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new PlanList());
        }

   

    }

  
}
