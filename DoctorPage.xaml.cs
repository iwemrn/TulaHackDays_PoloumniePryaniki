using System;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class DoctorPage : ContentPage
    {
        public ObservableCollection<string> Times { get; set; }

        public DoctorPage()
        {
            InitializeComponent();
            Times = new ObservableCollection<string>();
            BindingContext = this;
        }

        private void OnAddTimeClicked(object sender, EventArgs e)
        {
            Times.Add(TimePicker.Time.ToString(@"hh\:mm"));
        }

        private async void OnAddCourseClicked(object sender, EventArgs e)
        {
            try
            {
                var startDate = StartDatePicker.Date;
                var endDate = EndDatePicker.Date;
                var times = new List<TimeSpan>(Times.Select(t => TimeSpan.Parse(t)));

                await Navigation.PushAsync(new PatientPage(startDate, endDate, times));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Ошибка добавления курса: {ex.Message}", "OK");
            }
        }
    }
}
