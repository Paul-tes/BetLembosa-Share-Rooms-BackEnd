
using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd;

public class CreateWishList
{
  [Required]
  public Guid HomeId { get; set; }
}
