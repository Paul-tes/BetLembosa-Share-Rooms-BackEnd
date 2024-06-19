namespace BetLembosa_Share_Rooms_BackEnd;

public class CommentDto
{
  public Guid Id { get; set; }
  public Guid UserId { get; set; }
  public Guid HomeId { get; set; }
  public string Description { get; set; }
  public int Rating { get; set; }
}
