using Realms.Sync;
using SharpNotes.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace SharpNotes.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public ICommand RegisterCommand { get; }
        public ICommand LogInCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new AsyncCommand(RegisterCommandHandler);
            LogInCommand = new Command(LogInCommandHandler);
        }

        private async Task RegisterCommandHandler()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                await DisplayToastService.DisplayErrorToast("please enter a username and password");
                return;
            }
            else if (Password != ConfirmPassword)
            {
                await DisplayToastService.DisplayErrorToast("passwords do not match");
                return;
            }

            try
            {
                (string username, string password) creds = new(Username, Password);
                await App.RealmApp.EmailPasswordAuth.RegisterUserAsync(creds.username, creds.password);
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

        private async void LogInCommandHandler() => await NavigationService.GoBack();
    }
}
