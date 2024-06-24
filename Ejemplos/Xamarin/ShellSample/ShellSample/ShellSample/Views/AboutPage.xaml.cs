using System.Linq;
using Xamarin.Forms;

namespace ShellSample.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var state = Shell.Current.CurrentState;
            var originalString = state.Location.OriginalString;
            var lastpage = state.Location.OriginalString.Split('/').LastOrDefault();
        }
    }
}