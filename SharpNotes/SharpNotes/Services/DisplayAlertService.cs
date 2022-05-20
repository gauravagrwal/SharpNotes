using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharpNotes.Services
{
    public static class DisplayAlertService
    {
        public static Page CurrentPage => Application.Current.MainPage;

        public static async Task ShowAlert(string title, string message, string cancel = "Ok")
        {
            if (CurrentPage == null)
            {
                throw new Exception();
            }
            await CurrentPage.DisplayAlert(title, message, cancel);
        }
    }
}
