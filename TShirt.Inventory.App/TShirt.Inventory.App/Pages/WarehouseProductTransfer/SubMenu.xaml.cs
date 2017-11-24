using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TShirt.Inventory.App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirt.Inventory.App.Pages.WarehouseProductTransfer
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubMenu : ContentPage
    {
        public SubMenu()
        {
            InitializeComponent();
            BindingContext = new SubMenuViewModelTransaction();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;
    }

    public class SubMenuViewModelTransaction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
        public SubMenuViewModelTransaction()
        {
            LoadMenu();
        }

        public void LoadMenu()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>();

            MenuItems.Add(new MenuItemViewModel
            {
                Id = 12,
                Icon = "@drawable/add.png",
                Name = "Crear Solicitud",
                Page = "Pages/Count/PlanList"
            });
            MenuItems.Add(new MenuItemViewModel
            {
                Id = 13,
                Icon = "@drawable/list.png",
                Name = "Ver Solicitud",
                Page = "Pages/Count/PlanList"
            });

        }


    }
}
