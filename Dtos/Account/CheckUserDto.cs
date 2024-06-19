using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd;

public class CheckUserDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; }
}
