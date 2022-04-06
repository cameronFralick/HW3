using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using MyAwesomeApp.Services;
using MyAwesomeApp.Views;
using System.IO;



namespace MyAwesomeApp.ViewModels
{
    internal class SaveSelectorViewModel : BindableObject
    {

        public string SaveName { get; set; }

        public string TestText { get; set; }

        public ICommand SubmitCommand { get; }

        public ItemService TheItemService { get; set; }

        public string Pathway { get; set; }

        public SaveSelectorViewModel()
        {
            TestText = "Save Selector";
            SaveName = "DefaultSave";
            SubmitCommand = new Command(Submit);
            TheItemService = new ItemService();
            Pathway = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/FileName.txt");
            
        }

        void Submit()
        {
            TestText = "Works";
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/FileName.txt", SaveName);
            
        }
    }
}
