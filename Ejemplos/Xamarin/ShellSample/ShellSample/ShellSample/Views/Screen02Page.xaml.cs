using ShellSample.ViewModels;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Screen02Page : ContentPage
    {
        public Screen02Page()
        {
            InitializeComponent();
            BindingContext = new Screen02ViewModel();
        }

        protected override void OnAppearing()
        {
            var state = Shell.Current.CurrentState;
            var originalString = state.Location.OriginalString;
            var lastpage = state.Location.OriginalString.Split('/').LastOrDefault();
        }
    }
}