using ShellSample.ViewModels;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Screen01Page : ContentPage
    {
        public Screen01Page()
        {
            InitializeComponent();
            BindingContext = new Screen01ViewModel();
        }

        protected override void OnAppearing()
        {
            var state = Shell.Current.CurrentState;
            var originalString = state.Location.OriginalString;
            var lastpage = state.Location.OriginalString.Split('/').LastOrDefault();
        }
    }
}