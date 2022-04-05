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




namespace MyAwesomeApp.ViewModels
{
    internal class ListPageViewModel : BindableObject
    {
        public ObservableCollection<Item> Items { get; set; }

        public ItemService itemService { get; set; }

        
        public ICommand RefreshCommand { get; }

        public bool isBusy { get; set; }
        

        public ListPageViewModel()
        {
            isBusy = false;
            RefreshCommand = new Command(RefreshView);

            itemService = new ItemService();
            Items = new ObservableCollection<Item>(itemService.GetTasks());

            
            Items.Add(new Models.Task("Task1", "This is description one", "12-34", false));
            Items.Add(new Models.Task("Task2", "this is description 2", "12-34", true));
            Items.Add(new Models.Task("Task3", "this is description 3", "12-34", false));


        }
        /*private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            itemService.SetList(Items.ToList());
        }*/

        async void RefreshView()
        {
            isBusy = true;
            await System.Threading.Tasks.Task.Delay(10);
            Items.Clear();
            
            isBusy = false;
        }


        
    }

}
