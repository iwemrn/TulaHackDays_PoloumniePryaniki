using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // Для использования Preferences

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Установка MainPage с учётом нового пространства имен для LoginPage
            MainPage = new NavigationPage(new Pages.LoginPage());

            // Установите глобальное имя приложения с помощью Preferences
            Preferences.Set("AppName", "MedTalk");
        }
    }
}
