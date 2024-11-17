using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace MauiApp1.Pages
{
    public partial class NotesPage : ContentPage
    {
        public ICommand PhoneCallCommand { get; private set; }

        public NotesPage()
        {
            InitializeComponent();
            PhoneCallCommand = new Command(() => OpenPhoneApp("89991234567"));
            BindingContext = this;
        }

        private void OpenPhoneApp(string phoneNumber)
        {
            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", "Не удалось открыть приложение телефона: " + ex.Message, "OK");
            }
        }
    }
}
