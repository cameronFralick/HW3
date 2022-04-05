
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using MyAwesomeApp.Services;
using MyAwesomeApp.Views;

namespace MyAwesomeApp.ViewModels
{
    internal class AddTaskPageViewModel : BindableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public bool isCompleted { get; set; }
        public ICommand Submit { get; }
        public AddTaskPageViewModel()
        {
            Name = "Name";
            Description = "Description";
            Deadline = "MM/YY";
            isCompleted = false;
            Submit = new Command(SubmitCommand);
        }

        async void SubmitCommand()
        {
            ItemService theStuff = new ItemService();
            theStuff.AddTask(Name, Description, Deadline, isCompleted);
            await Shell.Current.GoToAsync("//AddPage");
        }
    }
}
