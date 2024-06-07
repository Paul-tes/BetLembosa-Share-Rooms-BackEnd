using System;
using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd
{
    public class TripDto
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public Guid HomeId { get; set; }

        // Navigation properties
        public AppUser User { get; set; }
        public HomeDto Home { get; set; }

        // Additional trip information
        public string TripInfo { get; set; }
    }
}
