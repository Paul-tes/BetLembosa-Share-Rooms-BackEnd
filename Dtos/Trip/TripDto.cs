using System;
using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd
{
    public class TripDto
    {
        public Guid Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        // Navigation properties
        public required string UserId { get; set; }
        
        public required string HomeId { get; set; }

        public required string StartDate { get; set; }    
        public required string EndDate { get; set; }
        public required bool Paid { get; set; }
    }
}
