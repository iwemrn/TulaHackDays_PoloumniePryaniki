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
                "13.01.24 ��������: 120/80",
                "13.01.24 �����: 5.5",
                "14.01.24 ��������: 118/78",
                "14.01.24 �����: 5.3"
            };
            BindingContext = this;
        }

        // ���������� �������� ����
        private async void OnUploadPhotoClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "�������� �����������",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    // �������� ����������
                    UserPhoto.Source = ImageSource.FromFile(result.FullPath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("������", "�� ������� ��������� ����: " + ex.Message, "OK");
            }
        }

        public void AddReading(string reading)
        {
            Readings.Add(reading);
        }

        // ���������� ������ "������� ������"
        private async void OnCallEmergency(object sender, EventArgs e)
        {
            try
            {
                // ������������ ������ �� ������ 112
                PhoneDialer.Open("112");
            }
            catch (Exception ex)
            {
                await DisplayAlert("������", "�� ������� ��������� ������: " + ex.Message, "OK");
            }
        }
    }
}
