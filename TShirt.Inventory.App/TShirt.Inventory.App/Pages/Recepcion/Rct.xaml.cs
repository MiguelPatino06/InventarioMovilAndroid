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
    public partial class Rct : ContentPage
    {
        public Rct(string ordercode, RctExtendModel rct)
        {
            InitializeComponent();
            BindingContext = new RctViewModel(ordercode, rct);
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Menu());
        }
    }

  
}
