using SharpNotes.Views;
using Xamarin.Forms;

namespace SharpNotes
{
    public partial class App : Application
    {
        private const string APP_ID = "tutorialapp-rwltr";
        public static Realms.Sync.App RealmApp;

        public App() => InitializeComponent();

        protected override void OnStart()
        {
            RealmApp = Realms.Sync.App.Create(APP_ID);
            
            if (RealmApp.CurrentUser == null)
                MainPage = new NavigationPage(new LogInPage());

            else
                MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
