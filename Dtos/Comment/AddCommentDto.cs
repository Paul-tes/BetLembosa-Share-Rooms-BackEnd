using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd;

public class AddCommentDto
{
  [Required]
  public string Description { get; set; }
  [Required]
  public string HomeId { get; set; }
  [Required]
  public int Rating { get; set; }

}
