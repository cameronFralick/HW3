using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using MyAwesomeApp.Services;
using MyAwesomeApp.Models;
using System.Linq;
using System.Collections.ObjectModel;




namespace MyAwesomeApp.ViewModels
{
    internal class ListPageViewModel : BindableObject
    {
        public ObservableCollection<Item> Items { get; set; }

        public ItemService itemService { get; set; }

        

        

        public ListPageViewModel()
        {
            

            itemService = new ItemService();
            Items = new ObservableCollection<Item>(itemService.GetTasks());

            
            Items.Add(new Task("Task1", "This is description one", "12-34", false));
            Items.Add(new Task("Task2", "this is description 2", "12-34", true));
            Items.Add(new Task("Task3", "this is description 3", "12-34", false));


        }
        /*private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            itemService.SetList(Items.ToList());
        }*/

        
    }

}
