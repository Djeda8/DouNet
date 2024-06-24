using ShellSample.Views;
using System;
using Xamarin.Forms;

namespace ShellSample
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("Screen01Detail", typeof(Screen01DetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        protected async override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
            string source = args.Source.ToString();
            string target = args.Target != null ? args.Target.Location.ToString() : "";
            string current = args.Current != null ? args.Current.Location.ToString() : "";
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            string source = args.Source.ToString();
            string previous = args.Previous != null ? args.Previous.Location.ToString() : "";
            string current = args.Current != null ? args.Current.Location.ToString() : "";
        }
    }
}
