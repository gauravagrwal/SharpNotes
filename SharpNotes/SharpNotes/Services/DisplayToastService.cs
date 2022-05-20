using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace SharpNotes.Services
{
    public static class DisplayToastService
    {
        public static Task DisplayErrorToast(string msg)
        {
            var messageOptions = new MessageOptions
            {
                Message = msg
            };

            var errorOptions = new ToastOptions
            {
                MessageOptions = messageOptions,
                Duration = System.TimeSpan.FromSeconds(3),
                BackgroundColor = Color.Red
            };

            return Application.Current.MainPage.DisplayToastAsync(errorOptions);
        }
    }
}
