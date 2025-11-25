using System;
using SQLite; // Required for SQLite attributes

namespace oculus_sport.Models
{
    public class Booking
    {
<<<<<<< HEAD
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
=======
        // [PrimaryKey] ensures the local booking record can be looked up quickly.
        [PrimaryKey] 
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(); 
        
        // Use [Indexed] for efficient querying in SQLite (e.g., finding all of a user's bookings)
        [Indexed]
        public string UserId { get; set; }
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632

        // Initialized to empty strings to satisfy .NET 9 Null Safety
        public string UserId { get; set; } = string.Empty;

        public string FacilityName { get; set; } = string.Empty;
        public string FacilityImage { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public DateTime Date { get; set; }
<<<<<<< HEAD
        public string TimeSlot { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        public string ContactName { get; set; } = string.Empty;
        public string ContactStudentId { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;

        public string TotalCost { get; set; } = "Free";
=======
        public string TimeSlot { get; set; } 
        public string Status { get; set; } = "Pending";

        // Contact Details
        public string ContactName { get; set; }
        public string ContactStudentId { get; set; }
        public string ContactPhone { get; set; }

        // Payment
        public string TotalCost { get; set; } = "Rp 50.000"; 
>>>>>>> 661b34ebaaf46adca5f6dda231a79a2cbe502632
    }
}