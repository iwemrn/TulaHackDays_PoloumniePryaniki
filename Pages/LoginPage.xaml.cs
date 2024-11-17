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

        // ���������� ������ "�����"
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;

            // �������� �����
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("������", "������� ����� � ������.", "OK");
                return;
            }

            // ������ �����
            await DisplayAlert("�����", "�� ����� � �������.", "OK");

            // ��������� AppShell ��� ������� ��������
            Application.Current.MainPage = new AppShell();

            // ������� �� �������� "������ �������"
            await Shell.Current.GoToAsync("//user");
        }

        // ����������� ��������
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

        // ���������� �������������� ������
        private async void OnRestorePasswordClicked(object sender, EventArgs e)
        {
            await DisplayAlert("����������", "������ �� �������������� ������ ���������� ��� �� �����!", "OK");
        }
    }
}
