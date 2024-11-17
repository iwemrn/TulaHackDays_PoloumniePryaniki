using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace MauiApp1.Pages
{
    public partial class CalendarPage : ContentPage
    {
        public ObservableCollection<Reading> Readings { get; set; }

        public CalendarPage()
        {
            InitializeComponent();
            Readings = new ObservableCollection<Reading>();
            ReadingsCollection.ItemsSource = Readings;
        }

        // Обработчик добавления показания
        private void OnAddReadingClicked(object sender, EventArgs e)
        {
            Readings.Add(new Reading { Date = "", Name = "", Value = "" });
        }

        // Обработчик удаления показания
        private async void OnDeleteReadingClicked(object sender, EventArgs e)
        {
            if (Readings.Count > 0)
            {
                Readings.RemoveAt(Readings.Count - 1);
            }
            else
            {
                await DisplayAlert("Внимание", "Вы пытаетесь удалить важный показатель!", "OK");
            }
        }

        // Обработчик передачи показаний
        private async void OnSubmitReadingsClicked(object sender, EventArgs e)
        {
            bool isValid = true;

            foreach (var reading in Readings)
            {
                if (string.IsNullOrWhiteSpace(reading.Date) ||
                    string.IsNullOrWhiteSpace(reading.Name) ||
                    string.IsNullOrWhiteSpace(reading.Value))
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                await DisplayAlert("Ошибка", "Введите показания!", "OK");
                return;
            }

            // Добавление показаний в личный кабинет
            var profilPage = Routing.GetOrCreateContent("doctor") as ProfilPage;

            foreach (var reading in Readings)
            {
                profilPage?.AddReading($"{reading.Date}: {reading.Name} - {reading.Value}");
            }

            await DisplayAlert("Успех", "Показания переданы врачу!", "OK");
        }
    }

    public class Reading
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
