using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd;

public class CreateHomeDto
{
  [Required]
  [StringLength(100, ErrorMessage = "LocationType length can't be more than 100.")]
  public string homeType { get; set; }
  [Required]
  [StringLength(100, ErrorMessage = "PlaceType length can't be more than 100.")]
  public string PlaceType { get; set; }
  [Required]
  public string MapData { get; set; }  // Assume this is a JSON data
  [Required]
  public string LocationData { get; set; }
  [Required]
  public string PlaceSpace { get; set; }
  [Required]
  public List<string> PlaceAmenities { get; set; }
  [Required]
  public List<string> Photos { get; set; }  // This is a list
  [Required]
  [StringLength(200, ErrorMessage = "Title length can't be more than 200.")]
  public string Title { get; set; }
  [Required]
  [StringLength(500, ErrorMessage = "Description length can't be more than 500.")]
  public string Description { get; set; }
  [Required]
  [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
  public decimal Price { get; set; }
}
