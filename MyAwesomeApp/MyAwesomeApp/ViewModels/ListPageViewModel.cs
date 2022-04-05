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

        public ObservableCollection<KeyValuePair<string, Item>> ItemTypes { get; set; }

        

        public ListPageViewModel()
        {
            

            itemService = new ItemService();
            Items = new ObservableCollection<Item>(itemService.GetTasks());

            ItemTypes = new ObservableCollection<KeyValuePair<string, Item>>();
            for(int i = 0; i < Items.Count; i++)
            {
                if(Items[i] is Task)
                {
                    ItemTypes.Add(new KeyValuePair<string, Item>("Task", Items[i]));
                }
                else
                {
                    ItemTypes.Add(new KeyValuePair<string, Item>("Appointment", Items[i]));
                }
            }
            Items.Add(new Task("A", "B,", "12-34", false));
            Items.Add(new Task("B", "B,", "12-34", true));
            Items.Add(new Task("C", "B,", "12-34", false));


        }
        /*private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            itemService.SetList(Items.ToList());
        }*/

        
    }

}
