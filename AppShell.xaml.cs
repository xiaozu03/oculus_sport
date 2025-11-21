using oculus_sport.Views.Auth;
using oculus_sport.Views.Main;

namespace oculus_sport;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register Detail Routes (Pages that are NOT in the bottom tab bar)
        // These allow you to use Shell.Current.GoToAsync(nameof(Page))
        Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
    }
}