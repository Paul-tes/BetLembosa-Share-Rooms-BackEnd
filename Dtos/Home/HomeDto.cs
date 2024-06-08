using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd
{
    public class HomeDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "LocationType length can't be more than 100.")]
        public string LocationType { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PlaceType length can't be more than 100.")]
        public string PlaceType { get; set; }

        [Required]
        public string MapData { get; set; }

        [Required]
        public string LocationData { get; set; }

        [Required]
        public string PlaceSpace { get; set; }

        [Required]
        public string PlaceAmenities { get; set; }

        [Required]
        public string Photos { get; set; }

        [Required]
        public AppUser CreatedBy { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Title length can't be more than 200.")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description length can't be more than 500.")]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public double Rating { get; set; } = 0;
    }
}
