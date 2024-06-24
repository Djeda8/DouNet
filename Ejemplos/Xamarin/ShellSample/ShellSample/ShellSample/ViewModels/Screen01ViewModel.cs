using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellSample.ViewModels
{
    public class Screen01ViewModel
    {
        public Command GoScreen01DetailCommand => new Command(async () => await GoScreen01DetailCommandExecute());

        private async Task GoScreen01DetailCommandExecute()
        {
            await Shell.Current.GoToAsync("Screen01Detail");
        }

        public Screen01ViewModel()
        {
                
        }
    }
}
