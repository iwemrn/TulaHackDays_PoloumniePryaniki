using MauiApp1.Pages;

namespace MauiApp1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Регистрация маршрутов для навигации
        Routing.RegisterRoute("calendar", typeof(CalendarPage));
        Routing.RegisterRoute("pills", typeof(PillsPage));
        Routing.RegisterRoute("notes", typeof(NotesPage));
        Routing.RegisterRoute("profile", typeof(ProfilPage));
    }
}
