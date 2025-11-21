using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using oculus_sport.Models;
using oculus_sport.Services;
using oculus_sport.ViewModels.Base;

namespace oculus_sport.ViewModels.Main;

public partial class HistoryPageViewModel : BaseViewModel
{
    private readonly IBookingService _bookingService;

    [ObservableProperty]
    private ObservableCollection<Booking> _myBookings = new();

    [ObservableProperty]
    private bool _hasNoBookings;

    public HistoryPageViewModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
        Title = "Booking History";
    }

    [RelayCommand]
    async Task LoadBookings()
    {
        if (IsBusy) return;
        IsBusy = true;

        // 1. Fetch data
        var list = await _bookingService.GetUserBookingsAsync("Tony");

        // 2. Clear and Add
        MyBookings.Clear();
        foreach (var item in list)
        {
            MyBookings.Add(item);
        }

        // 3. Update Empty State
        HasNoBookings = MyBookings.Count == 0;

        IsBusy = false;
    }
}