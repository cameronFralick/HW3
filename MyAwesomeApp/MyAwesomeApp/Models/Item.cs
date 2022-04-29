using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAwesomeApp.Models
{

    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Priority { get; set; }

        public string ItemType {  get; set; }
    }


    public class Task : Item
    {

        public string Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public Task()
        {

        }

        public Task(string name, string description, string deadline, bool isCompleted)
        {
            this.Name = name;
            this.Description = description;
            this.Deadline = deadline;
            this.IsCompleted = isCompleted;
            this.Priority = false;
            this.ItemType = "T";
        }

        public override string ToString()
        {
            return $"Task - Name: {Name} - Description: {Description} - Deadline: {Deadline} - Is Completed: {IsCompleted}";
        }
    }

    public class CalendarAppointment : Item
    {

        public DateTime start { get; set; }
        public DateTime stop { get; set; }

        public List<String> Attendees;

        public CalendarAppointment()
        {

        }

        public CalendarAppointment(string name, string description, DateTime start, DateTime stop, List<String> Attendees)
        {
            this.Name = name;
            this.Description = description;
            this.start = start;
            this.stop = stop;
            this.Attendees = Attendees;
            this.ItemType = "A";
        }

        public override string ToString()
        {
            return $"CalendarAppointment - Name: {Name} - Description: {Description} - Start: {start} - Stop: {stop} - Num Attendees: {Attendees.Count}";
        }

    }
}
