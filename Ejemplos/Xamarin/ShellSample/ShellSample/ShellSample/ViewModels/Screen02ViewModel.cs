using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellSample.ViewModels
{
    public class Screen02ViewModel
    {
        public Command GoScreen01DetailCommand => new Command(async () => await GoScreen01DetailCommandExecute());

        private async Task GoScreen01DetailCommandExecute()
        {
            await Shell.Current.GoToAsync("//Screen01/Screen01Detail");
        }
        public Screen02ViewModel()
        {

        }
    }
}
