using Realms.Sync;
using SharpNotes.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace SharpNotes.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LogInCommand { get; }
        public ICommand RegisterCommand { get; }

        public LogInViewModel()
        {
            LogInCommand = new AsyncCommand(LogInCommandHandler);
            RegisterCommand = new Command(RegisterCommandHandler);
        }

        private async Task LogInCommandHandler()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await DisplayToastService.DisplayErrorToast("please enter a username and password");
                return;
            }

            try
            {
                (string username, string password) creds = new(Username, Password);
                var user = await App.RealmApp.LogInAsync(Credentials.EmailPassword(creds.username, creds.password));
                if (user != null)
                {
                    await NavigationService.NavigateTo(new NotesViewModel());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertService.ShowAlert("Error", ex.Message);
            }
        }

        private async void RegisterCommandHandler() => await NavigationService.NavigateTo(new RegisterViewModel());
    }
}
