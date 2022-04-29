using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using MyAwesomeApp.Services;
using System.Linq;
using MyAwesomeApp.Services;
using Newtonsoft.Json;
using MyAwesomeApp.Models;

namespace MyAwesomeApp.ViewModels
{
    internal class AddAppointmentPageViewModel : BindableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string attendeeString { get; set; }
        public ICommand Submit { get; }
        public WebItemService webItemService { get; set; }
        public AddAppointmentPageViewModel()
        {
            Name = "Name";
            Description = "Description";
            Start = new DateTime();
            Stop = new DateTime();
            attendeeString = "Mark,John,Mildred,Mills,etc.";

            webItemService = new WebItemService();

            Submit = new Command(SubmitCommand);
        }

        async void SubmitCommand()
        {   
            List<string> theAttendees = attendeeString.Split(',').ToList();
            ItemService theStuff = new ItemService();
            theStuff.AddAppointment(Name, Description, Start, Stop, theAttendees);

            WebItemService webItemService = new WebItemService();
            CalendarAppointment newAppointment = new CalendarAppointment(Name, Description, Start, Stop, theAttendees);
            await webItemService.Post("http://192.168.1.144:5262/Item/AddOrUpdateAppointment", newAppointment);


            await Shell.Current.GoToAsync("//AddPage");
            
        }
    }
}
