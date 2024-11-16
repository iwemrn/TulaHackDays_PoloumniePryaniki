using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MauiApp1
{
    public partial class PatientPage : ContentPage
    {
        public ObservableCollection<DateBlock> Dates { get; set; }

        public PatientPage()
        {
            InitializeComponent();
            Dates = new ObservableCollection<DateBlock>();
            BindingContext = this;
        }

        public PatientPage(DateTime startDate, DateTime endDate, List<TimeSpan> times)
        {
            InitializeComponent();

            Dates = new ObservableCollection<DateBlock>();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                Dates.Add(new DateBlock
                {
                    DateText = date.ToShortDateString(),
                    Times = new ObservableCollection<TimeBlock>(
                        times.Select(time => new TimeBlock
                        {
                            TimeText = time.ToString(@"hh\:mm"),
                            MarkTakenCommand = new Command(() => MarkTimeTaken(date, time))
                        })
                    )
                });
            }

            BindingContext = this;
        }

        private async void MarkTimeTaken(DateTime date, TimeSpan time)
        {
            var actualTime = DateTime.Now.TimeOfDay;
            var difference = Math.Abs((actualTime - time).TotalMinutes);

            if (difference <= 30)
            {
                await DisplayAlert("Принято", $"Принято: {date.ToShortDateString()} {time:hh\\:mm}.", "OK");
            }
            else
            {
                await DisplayAlert("Внимание", $"Фактический прием отклонен на {difference:F0} минут.", "OK");
            }
        }
    }

    public class DateBlock
    {
        public string DateText { get; set; }
        public ObservableCollection<TimeBlock> Times { get; set; }
    }

    public class TimeBlock
    {
        public string TimeText { get; set; }
        public ICommand MarkTakenCommand { get; set; }
    }
}
