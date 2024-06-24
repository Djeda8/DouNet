using ShellSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Screen01DetailPage : ContentPage
    {
        public Screen01DetailPage()
        {
            InitializeComponent();
            BindingContext = new Screen01DetailViewModel();
        }

        protected override void OnAppearing()
        {
            var state = Shell.Current.CurrentState;
            var originalString = state.Location.OriginalString;
            var lastpage = state.Location.OriginalString.Split('/').LastOrDefault();
        }
    }
}