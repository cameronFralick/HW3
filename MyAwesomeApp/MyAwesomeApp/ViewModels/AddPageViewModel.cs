using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using MyAwesomeApp.Views;

namespace MyAwesomeApp.ViewModels
{
    public class AddPageViewModel : BindableObject
    {
        public AddPageViewModel()
        {
            GoToTaskAdd = new Command(ToTaskAdd);

            GoToAppointmentAdd = new Command(ToAppointmentAdd);
        }

        public ICommand GoToAppointmentAdd { get; }

        public ICommand GoToTaskAdd { get; }

        async void ToTaskAdd()
        {
            await Shell.Current.GoToAsync("//AddTaskPage");
        }

        async void ToAppointmentAdd()
        {
            await Shell.Current.GoToAsync("//AddAppointmentPage");
        }

        
    }
}
