using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace TShirt.Inventory.App.Droid
{
    [Activity(Label = "TShirt.Inventory.App", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            

        }

        //@Override

        //public void onLowMemory()
        //{
        //    OnTrimMemory(TrimMemory.Complete);
        //    this.onLowMemory();
        //}
        
        //public void onStop()
        //{
        //    OnTrimMemory(TrimMemory.UiHidden);
           
        //}


    }
}

