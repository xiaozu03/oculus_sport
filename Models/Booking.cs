using System;

namespace oculus_sport.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public string? UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
