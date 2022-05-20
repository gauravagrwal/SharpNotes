using Realms;
using SharpNotes.Models;
using SharpNotes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace SharpNotes.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        private readonly Realm _realm;

        public IEnumerable<Note> Notes { get; }

        public ICommand CreateNoteCommand { get; }
        public ICommand UpdateNoteCommand { get; }
        public ICommand DeleteNoteCommand { get; }

        public Note SelectedNote
        {
            get => null;
            set
            {
                UpdateNoteCommand.Execute(value);
                OnPropertyChanged();
            }
        }

        public NotesViewModel()
        {
            _realm = Realm.GetInstance();
            Console.WriteLine($"Realm is located at: {_realm.Config.DatabasePath}");
            Notes = _realm.All<Note>();

            CreateNoteCommand = new AsyncCommand(CreateEntryCommandHandler);
            UpdateNoteCommand = new AsyncCommand<Note>(UpdateEntryCommandHandler);
            DeleteNoteCommand = new Command<Note>(DeleteNoteCommandHandler);
        }

        private async Task CreateEntryCommandHandler()
        {
            var transaction = _realm.BeginWrite();
            var note = _realm.Add(new Note
            {
                MetaData = new MetaData
                {
                    CreatedDate = DateTimeOffset.Now,
                    LastModifiedDate = DateTimeOffset.Now
                }
            });
            
            await NavigationService.NavigateTo(new NoteDetailsViewModel(transaction, note));
        }

        private async Task UpdateEntryCommandHandler(Note note)
        {
            var transaction = _realm.BeginWrite();
            await NavigationService.NavigateTo(new NoteDetailsViewModel(transaction, note));
        }

        private void DeleteNoteCommandHandler(Note note)
        {
            _realm.Write(() => _realm.Remove(note));
        }
    }
}
