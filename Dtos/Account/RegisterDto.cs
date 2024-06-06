using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd;

public class RegisterDto
{
  [Required]
  public string? FirstName { get; set; }

  [Required]
  public string? LastName { get; set; } 

  [Required]
  public string? Email { get; set; }

  [Required]
  public string? Password { get; set; }
}
