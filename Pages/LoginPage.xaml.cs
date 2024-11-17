using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MauiApp1.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Войти"
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;

            // Проверка ввода
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Введите логин и пароль.", "OK");
                return;
            }

            // Пример входа
            await DisplayAlert("Успех", "Вы вошли в аккаунт.", "OK");

            // Установка AppShell как главной страницы
            Application.Current.MainPage = new AppShell();

            // Переход на страницу "Личный кабинет"
            await Shell.Current.GoToAsync("//user");
        }

        // Обработчики соцсетей
        private async void OnVkClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://vk.com");
        }

        private async void OnYandexClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://yandex.ru");
        }

        private async void OnTelegramClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://telegram.org");
        }

        // Обработчик восстановления пароля
        private async void OnRestorePasswordClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Информация", "Ссылка на восстановление пароля отправлена Вам на почту!", "OK");
        }
    }
}
