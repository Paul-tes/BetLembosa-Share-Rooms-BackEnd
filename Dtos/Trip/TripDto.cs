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
        [Required]
        public required string UserId { get; set; }
        
        public required string HomesIs { get; set; }

        // Additional trip information
        public required string TripInfo { get; set; }
        public required string PayementInfo { get; set; }
    }
}
