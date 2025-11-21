using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using oculus_sport.Models;
using oculus_sport.ViewModels.Base;

namespace oculus_sport.ViewModels.Main;

// This attribute allows us to receive the "Facility" object from the Home Page
[QueryProperty(nameof(Facility), "Facility")]
public partial class BookingViewModel : BaseViewModel
{
    [ObservableProperty]
    private Facility _facility;

    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Now;

    [ObservableProperty]
    private ObservableCollection<TimeSlot> _timeSlots = new();

    public BookingViewModel()
    {
        Title = "Select Time";
        GenerateTimeSlots();
    }

    // Re-generate slots when the date changes
    async partial void OnSelectedDateChanged(DateTime value)
    {
        // Simulate loading delay
        IsBusy = true;
        await Task.Delay(500);
        GenerateTimeSlots();
        IsBusy = false;
    }

    private void GenerateTimeSlots()
    {
        TimeSlots.Clear();

        // Mock Data: Generate slots from 8 AM to 10 PM
        DateTime start = DateTime.Today.AddHours(8);
        for (int i = 0; i < 14; i++)
        {
            var slotStart = start.AddHours(i);
            TimeSlots.Add(new TimeSlot
            {
                StartTime = slotStart.TimeOfDay,
                TimeRange = $"{slotStart:HH:00} - {slotStart.AddHours(1):HH:00}",
                IsAvailable = true // In future, check against database
            });
        }
    }

    [RelayCommand]
    void SelectSlot(TimeSlot slot)
    {
        if (slot == null) return;

        // Unselect others (Single selection mode)
        foreach (var s in TimeSlots) s.IsSelected = false;

        slot.IsSelected = true;
    }

    [RelayCommand]
    async Task ConfirmBooking()
    {
        var selectedSlot = TimeSlots.FirstOrDefault(s => s.IsSelected);
        if (selectedSlot == null)
        {
            await Shell.Current.DisplayAlert("Error", "Please select a time slot.", "OK");
            return;
        }

        // Logic to save booking would go here

        await Shell.Current.DisplayAlert("Success",
            $"Booking Confirmed!\nCourt: {Facility.Name}\nDate: {SelectedDate:d}\nTime: {selectedSlot.TimeRange}",
            "OK");

        // Navigate back to Home
        await Shell.Current.GoToAsync("..");
    }
}