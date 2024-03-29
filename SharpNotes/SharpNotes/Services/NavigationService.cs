﻿using SharpNotes.ViewModels;
using SharpNotes.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharpNotes.Services
{
    public static class NavigationService
    {
        private static INavigation Navigation => Application.Current.MainPage?.Navigation;

        private static void CheckNavigationSupport()
        {
            if (Navigation == null)
            {
                throw new InvalidOperationException("page does not support navigation");
            }
        }

        private static Page GetPageForViewModel(BaseViewModel viewModel)
        {
            return viewModel switch
            {
                LogInViewModel => new LogInPage(),
                RegisterViewModel => new RegisterPage(),
                NotesViewModel => new NotesPage(),
                NoteDetailsViewModel => new NoteDetailsPage(),
                _ => throw new ArgumentException($"The {viewModel} is not accepted"),
            };
        }
        
        public static async Task NavigateTo(BaseViewModel viewModel)
        {
            CheckNavigationSupport();

            var destinationPage = GetPageForViewModel(viewModel);
            destinationPage.BindingContext = viewModel;
            await Navigation.PushAsync(destinationPage, true);
        }

        public static async Task GoBack()
        {
            CheckNavigationSupport();

            await Navigation.PopAsync(true);
        }
    }
}
