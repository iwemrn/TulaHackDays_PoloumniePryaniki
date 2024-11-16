using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        private Patient _patient;

        public Patient Patient
        {
            get => _patient;
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public PatientViewModel()
        {
            // Инициализация данных пациента
            Patient = new Patient
            {
                Name = "Иван Иванов",
                Diagnosis = "Грипп",
                Notes = new List<string>
                {
                    "Принял лекарства по назначению.",
                    "Самочувствие немного улучшилось."
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
