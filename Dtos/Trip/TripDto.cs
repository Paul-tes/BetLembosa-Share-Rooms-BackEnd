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
        // Navigation properties
        public string UserId { get; set; }
        
        public ICollection<HomeDto> Homes { get; set; }

        // Additional trip information
        public string TripInfo { get; set; }
    }
}
