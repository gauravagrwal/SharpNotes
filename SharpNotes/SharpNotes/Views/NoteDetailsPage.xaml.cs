using SharpNotes.ViewModels;
using Xamarin.Forms;

namespace SharpNotes.Views
{
    public partial class NoteDetailsPage : ContentPage
    {
        public NoteDetailsPage() => InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as NoteDetailsViewModel)?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            (BindingContext as NoteDetailsViewModel)?.OnDisappearing();
        }
    }
}
