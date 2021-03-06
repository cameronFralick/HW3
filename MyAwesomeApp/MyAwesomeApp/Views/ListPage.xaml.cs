using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAwesomeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyAwesomeApp.Services;

namespace MyAwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel();
        }

        protected override void OnAppearing()
        {
            BindingContext = new ListPageViewModel();
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}