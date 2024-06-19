using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd
{
    public class WishlistDto
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public string UserId { get; set; }

        // Other properties and navigation properties as needed
        public ICollection<HomeDto> Homes { get; set; }
    }
}
