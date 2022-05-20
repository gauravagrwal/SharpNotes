using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharpNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            
            AppName.Text = AppInfo.Name.Split('.')[0];
            AppVersion.Text = $"v{VersionTracking.CurrentVersion}";
        }
    }
}
