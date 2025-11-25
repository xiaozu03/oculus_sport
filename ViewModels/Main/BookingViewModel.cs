using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using oculus_sport.Models;
using oculus_sport.Services;
<<<<<<< HEAD
using oculus_sport.ViewModels.Base;
=======
using System.Diagnostics;
using System.Text.Json; // Required for serializing the Booking object
using oculus_sport.Services.Auth;
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632

namespace oculus_sport.ViewModels.Main;

[QueryProperty(nameof(Facility), "Facility")]
public partial class BookingViewModel : BaseViewModel
{
    private readonly IBookingService _bookingService;
<<<<<<< HEAD

=======
    private readonly IAuthService _authService;

    // --- Observable Properties ---

    // NOTE: This property setter is the entry point for data passed from the previous page
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632
    [ObservableProperty]
    private Facility _facility = new(); 

    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Today;

    [ObservableProperty]
    private ObservableCollection<TimeSlot> _timeSlots = new();

<<<<<<< HEAD
    [ObservableProperty]
    private string _availabilityMessage = string.Empty;

    public BookingViewModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
        Title = "Select Time";
    }

    partial void OnFacilityChanged(Facility value) => GenerateTimeSlots();
    async partial void OnSelectedDateChanged(DateTime value)
    {
        IsBusy = true;
        await Task.Delay(300);
        GenerateTimeSlots();
        IsBusy = false;
    }

    private void GenerateTimeSlots()
    {
        TimeSlots.Clear();
        AvailabilityMessage = string.Empty;

        var day = SelectedDate.DayOfWeek;
        bool isOpen = false;
        List<string> validSlots = new();

        // 1. Check Rules based on Facility Name (Simulating DB rules)
        if (Facility.Name.Contains("Badminton"))
        {
            // Mon, Thu, Fri
            if (day == DayOfWeek.Monday || day == DayOfWeek.Thursday || day == DayOfWeek.Friday)
            {
                isOpen = true;
                validSlots = new List<string> { "10:00 - 12:00", "12:00 - 14:00", "14:00 - 16:00" };
            }
            else
            {
                AvailabilityMessage = "Badminton is only available on Mon, Thu, and Fri.";
            }
        }
        else if (Facility.Name.Contains("Ping-Pong"))
        {
            // Mon, Fri
            if (day == DayOfWeek.Monday || day == DayOfWeek.Friday)
            {
                isOpen = true;
                validSlots = new List<string> { "10:00 - 12:00", "12:00 - 14:00", "14:00 - 16:00" };
            }
            else
            {
                AvailabilityMessage = "Ping-Pong is only available on Mon and Fri.";
            }
        }
        else if (Facility.Name.Contains("Basketball"))
        {
            // Mon-Fri
            if (day != DayOfWeek.Saturday && day != DayOfWeek.Sunday)
            {
                isOpen = true;
                validSlots = new List<string> { "10:00 - 12:00", "12:00 - 14:00", "14:00 - 16:00", "16:00 - 18:00" };
            }
            else
            {
                AvailabilityMessage = "Basketball is closed on weekends.";
            }
        }

        // 2. Populate Slots if Open
        if (isOpen)
        {
            foreach (var slot in validSlots)
            {
                TimeSlots.Add(new TimeSlot { TimeRange = slot, IsAvailable = true });
            }
=======
    // --- Constructor (Dependency Injection) ---

    public BookingViewModel(IBookingService bookingService, IAuthService authService)
    {
        _bookingService = bookingService;
        _authService = authService;
        Title = "Select Time";

        // Data will be loaded in the Facility setter after navigation completes
    }

    // --- Data Loading Logic ---

    // This partial method runs automatically when the Facility property is set by QueryProperty
    async partial void OnFacilityChanged(Facility value)
    {
        // Load the time slots as soon as we know which facility was selected
        await LoadTimeSlotsAsync();
    }

    // This partial method runs automatically when the SelectedDate property changes
    async partial void OnSelectedDateChanged(DateTime value)
    {
        // Only load if the date is in the future or today
        if (value.Date >= DateTime.Today.Date)
        {
            await LoadTimeSlotsAsync();
        }
        else
        {
            await Application.Current.MainPage!.DisplayAlert("Invalid Date", "Cannot select a past date.", "OK");
            SelectedDate = DateTime.Today;
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632
        }
    }

    /// <summary>
    /// CRITICAL BACKEND INTEGRATION: Fetches real-time availability from the service layer.
    /// </summary>
    [RelayCommand]
    private async Task LoadTimeSlotsAsync()
    {
        if (IsBusy || Facility == null) return;
        IsBusy = true;
        TimeSlots.Clear();

        try
        {
            // 1. Check Auth State (Essential check before fetching personalized data)
            var user = _authService.GetCurrentUser();
            if (user == null)
            {
                // Optionally navigate to login or display a warning
            }

            // 2. Call IBookingService to fetch available slots
            Debug.WriteLine($"Fetching slots for {Facility.Name} on {SelectedDate.ToShortDateString()}");

            var availableSlots = await _bookingService.GetAvailableTimeSlotsAsync(Facility.Name, SelectedDate);

            // 3. Populate Observable Collection for the View
            foreach (var slot in availableSlots)
            {
                TimeSlots.Add(slot);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading time slots: {ex.Message}");
            await Application.Current.MainPage!.DisplayAlert("Error", "Failed to load court availability.", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    // --- User Interaction Commands ---

    [RelayCommand]
    void SelectSlot(TimeSlot slot)
    {
<<<<<<< HEAD
        if (slot == null) return;
=======
        if (slot == null || !slot.IsAvailable) return;

        // Unselect others (Single selection mode)
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632
        foreach (var s in TimeSlots) s.IsSelected = false;
        slot.IsSelected = true;
    }

    [RelayCommand]
    async Task ConfirmBooking()
    {
        var selectedSlot = TimeSlots.FirstOrDefault(s => s.IsSelected);
        if (selectedSlot == null)
        {
<<<<<<< HEAD
            // Show specific error if closed, or generic if just not selected
            string msg = string.IsNullOrEmpty(AvailabilityMessage) ? "Please select a time slot." : AvailabilityMessage;
            await Shell.Current.DisplayAlert("Unavailable", msg, "OK");
            return;
        }

        // Create Draft Booking
=======
            await Application.Current.MainPage!.DisplayAlert("Selection Required", "Please select an available time slot.", "OK");
            return;
        }

        // 1. Get current authenticated user ID
        var user = _authService.GetCurrentUser();
        if (user == null)
        {
            await Application.Current.MainPage!.DisplayAlert("Error", "Please sign in to make a booking.", "OK");
            return;
        }

        // 2. Create initial booking object
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632
        var draftBooking = new Booking
        {
            UserId = user.Id, // CRITICAL FIX: Use authenticated ID
            FacilityName = Facility.Name,
            FacilityImage = Facility.ImageUrl,
            Location = Facility.Location,
            Date = SelectedDate.Date, // Use only the date part
            TimeSlot = selectedSlot.SlotName, // CRITICAL FIX: Use SlotName
            Status = "Draft"
        };

<<<<<<< HEAD
        var navigationParameter = new Dictionary<string, object>
        {
            { "Booking", draftBooking }
=======
        // 3. Serialize object for navigation (safer than passing complex object directly)
        var bookingJson = JsonSerializer.Serialize(draftBooking);

        // 4. Navigate to Details Page (BookingDetailsViewModel)
        var navigationParameter = new Dictionary<string, object>
        {
            // Pass the serialized JSON string
            { "BookingData", bookingJson }
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632
        };

        await Shell.Current.GoToAsync(nameof(Views.Main.BookingConfirmationPage), navigationParameter); // Navigate to confirmation page now
    }
}