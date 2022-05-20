using SharpNotes.Views;
using Xamarin.Forms;

namespace SharpNotes
{
    public partial class App : Application
    {
        public App() => InitializeComponent();

        protected override void OnStart()
        {
            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
