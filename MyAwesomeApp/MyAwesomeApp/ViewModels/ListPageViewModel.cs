using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using MyAwesomeApp.Services;
using MyAwesomeApp.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MyAwesomeApp.Views;
using Newtonsoft.Json;





namespace MyAwesomeApp.ViewModels 
{
    internal class ListPageViewModel : BindableObject 
    {
        public ObservableCollection<Item> Items { get; set; }

        public ItemService itemService { get; set; }

        public WebItemService webItemService { get; set; }

        
        public ICommand RefreshCommand { get; }

        public ICommand DeleteCommand 
        { 
            get
            {
                return new Command((x) => DeleteStuff(x));
            }
        }

        public ICommand SaveCommand { get; }

        public bool isBusy { get; set; }
        
        

        public ListPageViewModel()
        {
            //isBusy = false;
            RefreshCommand = new Command(RefreshView);
            SaveCommand = new Command(SaveStuff);

            //itemService = new ItemService();
            //Items = new ObservableCollection<Item>(itemService.GetTasks());

            webItemService = new WebItemService();

            Items = new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(webItemService.Get("http://192.168.1.144:5262/Item/GetAll").Result, new ProductJsonConverter()));

        }
        


        async void DeleteStuff(object l)
        {
            ListView testView = (ListView)l;

            Item x = (Item)testView.SelectedItem;

            Items.Remove(x);

            //itemService.SetList(Items.ToList());

            await webItemService.Post("http://192.168.1.144:5262/Item/UpdateList", Items);
        }

        async void SaveStuff()
        {
            //itemService.SetList(Items.ToList());
            await webItemService.Post("http://192.168.1.144:5262/Item/UpdateList", Items);
        }

        async void RefreshView()
        {
            
            isBusy = true;

            await System.Threading.Tasks.Task.Delay(2000);
            Items.Clear();
            Items = new ObservableCollection<Item>(itemService.GetTasks());
            Items = new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(webItemService.Get("http://192.168.1.144:5262/Item/GetAll").Result));

            isBusy = false;
            
        }

        
        
    }

}
