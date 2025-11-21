using System;

namespace oculus_sport.Models
{
    public class Booking
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(); // Shorter ID for display
        public string UserId { get; set; }

        // Facility Details
        public string FacilityName { get; set; }
        public string FacilityImage { get; set; }
        public string Location { get; set; }

        // Time Details
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; } // e.g. "10:00 - 11:00"
        public string Status { get; set; } = "Pending"; // Changed default to Pending

        // Contact Details (New)
        public string ContactName { get; set; }
        public string ContactStudentId { get; set; }
        public string ContactPhone { get; set; }

        // Payment (New)
        public string TotalCost { get; set; } = "Rp 50.000"; // Simplified for now
    }
}