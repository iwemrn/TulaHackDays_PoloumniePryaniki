using Microsoft.Maui.Controls;
using System;

namespace MauiApp1.Pages
{
    public partial class PillsPage : ContentPage
    {
        public PillsPage()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на область (карточку)
        private async void OnCardTapped(object sender, EventArgs e)
        {
            if (sender is Frame frame)
            {
                string date = "13.01.2024";
                string medicine = "Амарил";
                string times = "08:00 - Таблетка принята\n20:00 - Таблетка принята";

                await DisplayAlert("Информация",
                    $"Дата приема таблеток: {date}\nНаименование: {medicine}\nВремя:\n{times}",
                    "OK");
            }
        }

        // Обработчик кнопки "Таблетка не принята"
        private async void OnNotTakenClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Text = "Таблетка принята";
                button.BackgroundColor = Color.FromHex("#1A0F42");
                button.IsEnabled = false;

                // Найти соответствующие Label и обновить их текст
                if (button.Parent?.Parent is Grid grid)
                {
                    foreach (var child in grid.Children)
                    {
                        if (child is VerticalStackLayout timesLayout)
                        {
                            foreach (var timeChild in timesLayout.Children)
                            {
                                if (timeChild is Label timeLabel && timeLabel.Text.Contains("Таблетка не принята"))
                                {
                                    timeLabel.Text = timeLabel.Text.Replace("Таблетка не принята", "Таблетка принята");
                                    break;
                                }
                            }
                        }
                    }
                }

                await DisplayAlert("Успех", "Таблетка была выпита в срок.", "OK");
            }
        }
    }
}
