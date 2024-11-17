using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Microsoft.Maui.Media;

namespace MauiApp1.Pages
{
    public partial class ProfilPage : ContentPage
    {
        public ObservableCollection<string> Readings { get; set; }

        public ProfilPage()
        {
            InitializeComponent();
            Readings = new ObservableCollection<string>
            {
                "13.01.24 Давление: 120/80",
                "13.01.24 Сахар: 5.5",
                "14.01.24 Давление: 118/78",
                "14.01.24 Сахар: 5.3"
            };
            BindingContext = this;
        }

        // Обработчик загрузки фото
        private async void OnUploadPhotoClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Выберите изображение",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    // Загрузка фотографии
                    UserPhoto.Source = ImageSource.FromFile(result.FullPath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Не удалось загрузить фото: " + ex.Message, "OK");
            }
        }

        public void AddReading(string reading)
        {
            Readings.Add(reading);
        }

        // Обработчик кнопки "Вызвать скорую"
        private async void OnCallEmergency(object sender, EventArgs e)
        {
            try
            {
                // Осуществляем звонок по номеру 112
                PhoneDialer.Open("112");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Не удалось совершить звонок: " + ex.Message, "OK");
            }
        }
    }
}
