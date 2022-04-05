using System;
using System.Collections.Generic;
using System.Text;
using MyAwesomeApp.Models;

namespace MyAwesomeApp.Services
{
    public interface IItemService
    {
        bool AddTask(string name, string description, string deadline, bool isCompleted);
        bool AddAppointment(string name, string description, DateTime start, DateTime stop, List<string> Attendees);

        bool RemoveItem(string name);

        List<Item> GetTasks();



    }
}
