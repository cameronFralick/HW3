using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAwesomeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveSelector : ContentPage
    {
        public SaveSelector()
        {
            InitializeComponent();
            BindingContext = new SaveSelectorViewModel();
        }
        
    }
}