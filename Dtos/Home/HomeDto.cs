namespace BetLembosa_Share_Rooms_BackEnd;
public class HomeDto
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public required string homeType { get; set; }
  public required string PlaceType { get; set; }
  public required string MapData { get; set; }
  public required string LocationData { get; set; }
  public required string PlaceSpace { get; set; }
  public required List<string> PlaceAmenities { get; set; }
  public required List<string> Photos { get; set; }
  public required string CreatedBy { get; set; }
  public required string CreatedById { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public decimal Price { get; set; }
  public double Rating { get; set; } = 0;
  public string CommentId { get; set; } = "";
}
