using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TShirt.Inventory.App.Models;
using TShirt.Inventory.App.Services;
using TShirt.Inventory.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirt.Inventory.App.Pages.Count
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanList : ContentPage
    {
        private CountServices countServices;
        public PlanList()
        {
            InitializeComponent();
            countServices = new CountServices();
           // BindingContext = new CountViewModel(null);
        }


        private async void ListCount_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CountViewModel viewModel = sender as CountViewModel;
            if (e.SelectedItem == null)
            {
                return;
            }
            var x = (CountPlan)e.SelectedItem;


            var result = await countServices.GetById(x.Id);
            if (result.Any(a => a.TotalProduct > 0))
            {
                var answer = await DisplayAlert("TSHIRT", x.Name + " ya tiene SubConteos, Desea Continuar un nuevo SubConteo?", "SI", "NO");
                if (answer)
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Plan(x.Id));

            }
            else
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Plan(x.Id));
                      
        }


        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
           //Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();


            //EntBarcode.Text = "";
            //EntBarcode.Focus();

        }

    }

   
}
