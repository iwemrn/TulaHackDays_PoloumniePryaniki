using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();  // Инициализация компонентов XAML
            MainPage = new AppShell();  // Установка AppShell как главной страницы
        }
    }
}