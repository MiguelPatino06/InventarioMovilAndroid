using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShirt.Inventory.App.Pages;
using Xamarin.Forms;


namespace TShirt.Inventory.App
{
    public partial class App : Application
    {
        private static App singleton;

        public App()
        {
            InitializeComponent();
           
            MainPage = new  NavigationPage(new Login());  //TShirt.Inventory.App.Pages.Login();
        }

        protected override void OnStart()
        {
            
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }




    }
}
