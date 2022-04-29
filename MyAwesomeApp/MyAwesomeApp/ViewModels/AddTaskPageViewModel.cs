
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using MyAwesomeApp.Services;
using MyAwesomeApp.Views;
using MyAwesomeApp.Models;

namespace MyAwesomeApp.ViewModels
{
    internal class AddTaskPageViewModel : BindableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public bool isCompleted { get; set; }
        public ICommand Submit { get; }
        public WebItemService webItemService { get; set; }
        public AddTaskPageViewModel()
        {
            Name = "Name";
            Description = "Description";
            Deadline = "MM/YY";
            isCompleted = false;
            Submit = new Command(SubmitCommand);

            webItemService = new WebItemService();
        }

        async void SubmitCommand()
        {
            Task newTask = new Task(Name, Description, Deadline, isCompleted);
            await webItemService.Post("http://192.168.1.144:5262/Item/AddOrUpdateTask", newTask);
            await Shell.Current.GoToAsync("//AddPage");
        }
    }
}
