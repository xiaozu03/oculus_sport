using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using oculus_sport.Services.Auth;
using oculus_sport.Services.Storage;
using oculus_sport.ViewModels.Auth;
using oculus_sport.ViewModels.Main;
using oculus_sport.Views.Auth;
using oculus_sport.Views.Main;

namespace oculus_sport;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit() // Initialize Community Toolkit
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // 1. Services (Singletons)
        builder.Services.AddSingleton<IAuthService, FirebaseAuthService>();
        // We use FirebaseDataService as the IDatabaseService implementation
        builder.Services.AddSingleton<IDatabaseService, FirebaseDataService>();
        builder.Services.AddSingleton<Services.Other.ConnectivityService>();

        // 2. ViewModels (Transient - created when needed)
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<SignUpPageViewModel>();
        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<SchedulePageViewModel>();
        builder.Services.AddTransient<EventPageViewModel>();
        builder.Services.AddTransient<ProfilePageViewModel>();
        builder.Services.AddTransient<HistoryPageViewModel>();
        builder.Services.AddTransient<BookingViewModel>();// Added based on wireframe Page 1 "View Booking Hist"

        // 3. Views (Transient)
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<SchedulePage>();
        builder.Services.AddTransient<EventPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<HistoryPage>();
        builder.Services.AddTransient<BookingPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}