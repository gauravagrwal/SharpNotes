using Realms;
using SharpNotes.Models;
using SharpNotes.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace SharpNotes.ViewModels
{
    public class NoteDetailsViewModel : BaseViewModel
    {
        private Transaction transaction;

        public Note Note { get; }

        public ICommand SaveNoteCommand { get; }

        public NoteDetailsViewModel(Transaction transaction, Note note)
        {
            this.transaction = transaction;
            Note = note;

            SaveNoteCommand = new AsyncCommand(SaveNoteCommandHandler);
        }

        private async Task SaveNoteCommandHandler()
        {
            if (string.IsNullOrEmpty(Note.Title) || string.IsNullOrEmpty(Note.Body))
            {
                await DisplayAlertService.ShowAlert("Error", "You cannot save a note with an empty title/body");
                return;
            }

            Note.MetaData.LastModifiedDate = DateTimeOffset.Now;
            transaction.Commit();
            transaction = null;
            await NavigationService.GoBack();
        }

        internal override void OnDisappearing() => transaction?.Dispose();
    }
}
