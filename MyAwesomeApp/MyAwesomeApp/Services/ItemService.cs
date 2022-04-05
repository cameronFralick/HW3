using System;
using System.Collections.Generic;
using System.Text;
using MyAwesomeApp.Models;
using Newtonsoft.Json;
using System.Runtime;
using System.IO;
using MyAwesomeApp.Services;

namespace MyAwesomeApp.Services
{
    public class ItemService
    {
        List<Item> theItems = new List<Item>();
        string persistencePath;
        JsonSerializerSettings serializerSettings;
        string fileNamePath;

        public ItemService()
        {

        }

        void Init()
        {
            //initialize path
            //initialize serializer
            //attempt to de-serialize
            
            fileNamePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\FileName.txt";

            //string fileName = File.ReadAllText(fileNamePath);
            persistencePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\defaulSave.json";
            serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            

            if(File.Exists(persistencePath))
            {
                var state = File.ReadAllText(persistencePath);
                theItems = JsonConvert.DeserializeObject<List<Item>>(state, serializerSettings) ?? new List<Item>();
            }
            else
            {
                theItems = new List<Item>();
                var savedList = JsonConvert.SerializeObject(theItems, serializerSettings);
                File.WriteAllText(persistencePath, savedList);
            }
        }


        public bool AddTask(string name, string description, string deadline, bool isCompleted)
        {

            Init();

            Task newTask = new Task(name, description, deadline, isCompleted);

            theItems.Add(newTask);

            if (File.Exists(persistencePath))
            {
                var state = File.ReadAllText(persistencePath);
                theItems = JsonConvert.DeserializeObject<List<Item>>(state, serializerSettings) ?? new List<Item>();
            }
            else
            {
                var savedList = JsonConvert.SerializeObject(theItems, serializerSettings);
                File.WriteAllText(persistencePath, savedList);
            }

            return true;
        }

        public bool AddAppointment(string name, string description, DateTime start, DateTime stop, List<string> Attendees)
        {
            Init();

            CalendarAppointment newAppt = new CalendarAppointment(name, description, start, stop, Attendees);

            theItems.Add(newAppt);

            if (File.Exists(persistencePath))
            {
                File.Delete(persistencePath);
                var savedList = JsonConvert.SerializeObject(theItems, serializerSettings);
                File.WriteAllText(persistencePath, savedList);
            }
            else
            {
                var savedList = JsonConvert.SerializeObject(theItems, serializerSettings);
                File.WriteAllText(persistencePath, savedList);
            }

            return true;
        }

        public bool RemoveItem(string name)
        {
            Init();
            bool removed = false;
            foreach(Item item in theItems)
            {
                if(item.Name == name)
                {
                    theItems.Remove(item);
                    removed = true;
                }
            }

            return removed;
        }

        public List<Item> GetTasks()
        {
            Init();
            return theItems;
        }

        public bool SetList(List<Item> newItems)
        {
            Init();
            theItems = newItems;

            if (File.Exists(persistencePath))
            {
                File.Delete(persistencePath);
                var savedList = JsonConvert.SerializeObject(theItems, serializerSettings);
                File.WriteAllText(persistencePath, savedList);
                return true;
            }
            else
            {
                var savedList = JsonConvert.SerializeObject(theItems, serializerSettings);
                File.WriteAllText(persistencePath, savedList);
                return true;
            }

        }
    }
}
