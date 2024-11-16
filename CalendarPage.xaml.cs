using Plugin.Calendars;
using Plugin.Calendars.Abstractions;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using MauiApp1.Models;

namespace MauiApp1;
public partial class CalendarPage : ContentPage
{
    public CalendarPage()
    {
        InitializeComponent();
    }

    private async void OnAddEventClicked(object sender, EventArgs e)
    {
        try
        {
            // Получаем список календарей на устройстве
            var calendars = await CrossCalendars.Current.GetCalendarsAsync();
            var defaultCalendar = calendars.FirstOrDefault();

            if (defaultCalendar == null)
            {
                StatusLabel.TextColor = Colors.Red;
                StatusLabel.Text = "Не удалось найти календарь на устройстве.";
                return;
            }

            // Создаем новое событие
            var newEvent = new CalendarEvent
            {
                Name = EventNameEntry.Text,
                Start = EventDatePicker.Date + EventStartTimePicker.Time,
                End = EventDatePicker.Date + EventEndTimePicker.Time,
                Reminders = new List<CalendarEventReminder>
                    {
                        new CalendarEventReminder { TimeBefore = TimeSpan.FromMinutes(15) } // Напоминание за 15 минут
                    }
            };

            // Добавляем событие в календарь
            await CrossCalendars.Current.AddOrUpdateEventAsync(defaultCalendar, newEvent);

            StatusLabel.TextColor = Colors.Green;
            StatusLabel.Text = "Событие добавлено успешно!";
        }
        catch (Exception ex)
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = $"Ошибка: {ex.Message}";
        }
    }
}