using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpNotes.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;

            OnPropertyChanged(propertyName);
            return true;
        }

        internal virtual void OnAppearing() { }

        internal virtual void OnDisappearing() { }
    }
}
