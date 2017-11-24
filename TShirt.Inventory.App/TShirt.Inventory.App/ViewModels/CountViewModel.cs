using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TShirt.Inventory.App.Models;
using TShirt.Inventory.App.Pages;
using TShirt.Inventory.App.Pages.Count;
using TShirt.Inventory.App.Services;
using Xamarin.Forms;
 

namespace TShirt.Inventory.App.ViewModels
{
    public class CountViewModel : INotifyPropertyChanged, IDisposable
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private CountServices countServices;
        private SyncServices syncServices;
        private const int ITEM_PER_PAGE = 10;


        public void Dispose()
        {
            Items.Clear();
            Details.Clear();
            DetailList.Clear();
        }


        public CountViewModel(int? id)
        {
            Items.Clear();
            Details.Clear();
            DetailList.Clear();

            countServices = new CountServices();
            syncServices = new SyncServices();

            //if (id == null)
            //    LoadItems();
            //else
            //    LoadDetailsPlan((int)id);

            User = "USER01";
          
        }


        #region METHODS
        private async void LoadDetailsPlan(int id)
        {
            IsPage = false;
            var list = new List<ViewCountPlanDetailExtend>();
            var result = await countServices.GetById(id);
            if (result != null)
            {
                list.AddRange(result.Select(item => new ViewCountPlanDetailExtend()
                {
                    Id = item.Id,
                    IdCountPlan = item.IdCountPlan,
                    Name = item.Name,
                    Description = item.Description,
                    ProductCode = item.ProductCode,
                    Quantity = item.Quantity,
                    TotalCounted = item.TotalCounted,
                    BarCode = item.BarCode,
                    ProductDescription = item.ProductDescription,
                    TotalProduct = item.TotalProduct,
                    HasDetails = (item.TotalProduct > 0) ? "Images/check.png" : "Images/uncheck.png",
                    ProductOk = (item.Quantity <= item.TotalProduct) ? "Images/yes.png" : "Images/no.png"
                }));

                if (list.Count() > 0)
                {
                    PlanName = result.FirstOrDefault().Name;
                    PlanDescription = result.FirstOrDefault().Name + " " + result.FirstOrDefault().Description;
                }


                ItemsCount = list.Count();
                NumberPage = 1;

                if (ItemsCount > 10)
                {
                    decimal valueItemscount = Convert.ToDecimal(list.Count());
                    decimal valueItemsperpages = Convert.ToDecimal(ITEM_PER_PAGE);
                    decimal valueResult = Math.Ceiling(valueItemscount / valueItemsperpages);

                    TotalPage = Convert.ToInt32(valueResult);

                    MsgPage = Convert.ToString(NumberPage) + " / " + Convert.ToString(TotalPage);
                    IsPage = true;
                }

                DetailList = new ObservableCollection<ViewCountPlanDetailExtend>(list.Take(ITEM_PER_PAGE)); 
                Details = new ObservableCollection<ViewCountPlanDetailExtend>(list);
            }
        }


        private async void NextPageList()
        {
            if (TotalPage != NumberPage)
            {                             
                var list = Details.Skip(NumberPage*ITEM_PER_PAGE).Take(ITEM_PER_PAGE).ToList();
                DetailList = new ObservableCollection<ViewCountPlanDetailExtend>(list);
                NumberPage += 1;
                MsgPage = Convert.ToString(NumberPage) + " / " + Convert.ToString(TotalPage);
            }
        }

        private async void PrevPageList()
        {
            
            NumberPage -= 1;
            if (NumberPage > 0)
            {
                MsgPage = Convert.ToString(NumberPage) + " / " + Convert.ToString(TotalPage);
                var list = (NumberPage > 1)
                    ? Details.Skip(NumberPage*ITEM_PER_PAGE).Take(ITEM_PER_PAGE).ToList()
                    : Details.Take(ITEM_PER_PAGE).ToList();
                DetailList = new ObservableCollection<ViewCountPlanDetailExtend>(list);
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private async void LoadItems()
        {
            var result = await countServices.GetAll();
            if (result != null)
            {
                Items = new ObservableCollection<CountPlan>(result);
            }
        }


        private async void Search()
        {
            var _list = Details;
            var result = _list.FirstOrDefault(a => a.BarCode == BCode);
            if (result != null)
            {
                Page x = new PlanDetails(result.IdCountPlan, result.ProductCode, User, PlanDescription, BCode,
                    result.ProductDescription);

                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new PlanDetails(result.IdCountPlan, result.ProductCode, User, PlanDescription, BCode, result.ProductDescription));
                //await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync(await PlanDetails(result.IdCountPlan, result.ProductCode, User, PlanDescription, BCode, result.ProductDescription));
                //await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync(x);
            }
            else
                MessageResult = "Producto no Registrado";


        }
        
        public async void Reload()
        {

            App.Current.MainPage.Navigation.NavigationStack.Last().FindByName<Button>("BtnRefresh").Text = "Buscando...";
            App.Current.MainPage.Navigation.NavigationStack.Last().FindByName<Button>("BtnRefresh").IsEnabled = false;

            var result = await syncServices.Execute("IV10300");

            if (result)
            {
                LoadItems();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("TSHIRT", "Error al sincronizar los planes de conteo", "OK");
            }

            App.Current.MainPage.Navigation.NavigationStack.Last().FindByName<Button>("BtnRefresh").Text = "Datos Actualizados";
            App.Current.MainPage.Navigation.NavigationStack.Last().FindByName<Button>("BtnRefresh").IsEnabled = true;
        }

        public async void ValidatePlan()
        {
            bool result = true;
            foreach (var item in Details.ToList())
            {
                if (item.TotalProduct == 0) result = false;
            }

            if (!result)
            {
                var answer = await App.Current.MainPage.DisplayAlert("TSHIRT", PlanName + " Aun tiene productos sin contar, Desea Continuar?", "SI", "NO");
                if (answer)
                {
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new PlanResume(Details.ToList(), PlanName));
                }
            }
            else
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new PlanResume(Details.ToList(), PlanName));



        }

        public async void Close()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Menu());
        }

        #endregion

        #region PROPERTIES

        private ObservableCollection<CountPlan> _items = new ObservableCollection<CountPlan>();

        public ObservableCollection<CountPlan> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                HeightList = (_items.Count * 45) + (_items.Count * 5);
                OnPropertyChanged("Items");
            }
        }


        private int _heightList;

        public int HeightList
        {
            get { return _heightList; }
            set
            {
                _heightList = value;
                OnPropertyChanged("HeightList");
            }
        }


        private ObservableCollection<ViewCountPlanDetailExtend> _details = new ObservableCollection<ViewCountPlanDetailExtend>();

        public ObservableCollection<ViewCountPlanDetailExtend> Details
        {
            get { return _details; }
            set
            {
                _details = value;
                //HeightList = (_details.Count * 80) + (_details.Count * 5);
                OnPropertyChanged("Details");
            }
        }


        private ObservableCollection<ViewCountPlanDetailExtend> _detailsList = new ObservableCollection<ViewCountPlanDetailExtend>();

        public ObservableCollection<ViewCountPlanDetailExtend> DetailList
        {
            get { return _detailsList; }
            set
            {
                _detailsList = value;
                HeightList = (_detailsList.Count * 80) + (_detailsList.Count * 5);
                OnPropertyChanged("DetailList");
            }
        }


        private string _planDescription;

        public string PlanDescription
        {
            get { return _planDescription; }
            set
            {
                _planDescription = value;
                OnPropertyChanged("PlanDescription");
            }
        }


        private string _messageResult;

        public string MessageResult
        {
            get { return _messageResult; }
            set
            {
                _messageResult = value;
                OnPropertyChanged("MessageResult");
            }
        }


        private string _bCode;

        public string BCode
        {
            get { return _bCode; }
            set
            {
                _bCode = value;
                OnPropertyChanged("BCode");
            }
        }

        private string _user;

        public string User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        private string _plan;

        public string PlanName
        {
            get { return _plan; }
            set
            {
                _plan = value;
                OnPropertyChanged("PlanName");
            }
        }

        #region PAGINACION

        private int _numberPage;

        public int NumberPage
        {
            get { return _numberPage; }
            set
            {
                _numberPage = value;
                OnPropertyChanged("NumberPage");
            }
        }

        private int _itemsCount;

        public int ItemsCount
        {
            get { return _itemsCount; }
            set
            {
                _itemsCount = value;
                OnPropertyChanged("ItemsCount");
            }
        }

        private int _totalPage;

        public int TotalPage
        {
            get { return _totalPage; }
            set
            {
                _totalPage = value;
                OnPropertyChanged("TotalPage");
            }
        }

        private string _msgPage;

        public string MsgPage
        {
            get { return _msgPage; }
            set
            {
                _msgPage = value;
                OnPropertyChanged("MsgPage");
            }
        }


        private bool _isPage;

        public bool IsPage
        {
            get { return _isPage; }
            set
            {
                _isPage = value;
                OnPropertyChanged("IsPage");
            }
        }
        #endregion


        #endregion

        #region COMMANDS

        public ICommand ProcessPlan
        {
            get { return new RelayCommand(ValidatePlan); }
        }

        public ICommand ClosePlan
        {
            get { return new RelayCommand(Close); }
        }

        public ICommand SearchProduct
        {
            get { return new RelayCommand(Search); }
        }

        public ICommand Refresh
        {
            get { return new RelayCommand(Reload); }
        }

        //PrevPage

        public ICommand PrevPage
        {
            get { return new RelayCommand(PrevPageList); }
        }


        public ICommand NextPage
        {
            get { return new RelayCommand(NextPageList); }
        }
        #endregion

    }
}
