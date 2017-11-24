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

namespace TShirt.Inventory.App.Pages.Count
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanDetails : ContentPage
    {
        private int idPlan = 0;
        //public int _id { get; set; }
        //public string _product { get; set; }
        //public string _user { get; set; }
        //public string _description { get; set; }
        //public string _barCodeProduct { get; set; }
        //public string _nameProduct { get; set; }

        public PlanDetails(int id, string product, string user, string description, string barCodeProduct, string nameProduct)
        {
            //this._id = id;
            //this._product = product;
            //this._user = user;
            //this._description = description;
            //this._barCodeProduct = barCodeProduct;
            //this._nameProduct = nameProduct;


            idPlan = id;
            InitializeComponent();
            BindingContext = new CountDetailViewModel(id, product, user, description, barCodeProduct, nameProduct);
            //EntrQuantity.Focus();
            //EntrQuantity.Text = string.Empty;
        }

        //private void GetPlanDetails(int id, string product, string user, string description, string barCodeProduct, string nameProduct)
        //{
        //    idPlan = id;
        //    BindingContext = new CountDetailViewModel(id, product, user, description, barCodeProduct, nameProduct);
        //}



        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Plan(idPlan));
        }

        protected override void OnAppearing()
        {
            //GetPlanDetails(_id, _product, _user, _description, _barCodeProduct, _nameProduct);
            base.OnAppearing();

            

            EntrQuantity.Focus();
            EntrQuantity.Text = "";

          
           
        }
 
    }

  
}
