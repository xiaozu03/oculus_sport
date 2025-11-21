using CommunityToolkit.Mvvm.ComponentModel;

namespace oculus_sport.Models;

public partial class TimeSlot : ObservableObject
{
    public string TimeRange { get; set; } = string.Empty; // e.g., "10:00 - 11:00"
    public TimeSpan StartTime { get; set; }
    public bool IsAvailable { get; set; } = true;

    // Using private field for selection state (Standard Toolkit syntax)
    [ObservableProperty]
    private bool _isSelected;
}