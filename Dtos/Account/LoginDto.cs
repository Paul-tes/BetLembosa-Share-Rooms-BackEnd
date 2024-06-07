using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd;

public class LoginDto
{
  [Required]
  public string UserName { get; set; }

  [Required]
  public string Password { get; set; }
}
