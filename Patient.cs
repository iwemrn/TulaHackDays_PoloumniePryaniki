namespace MauiApp1
{
    public class Patient
    {
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public List<string> Notes { get; set; }
        public bool IsAttachedToDoctor { get; set; }
        public List<DateBlock> MedicationSchedule { get; set; } = new List<DateBlock>();
    }

    public class DateBlock
    {
        public string DateText { get; set; }
        public List<TimeBlock> Times { get; set; } = new List<TimeBlock>();
    }

    public class TimeBlock
    {
        public string TimeText { get; set; }
        public bool IsTaken { get; set; }
    }
}
