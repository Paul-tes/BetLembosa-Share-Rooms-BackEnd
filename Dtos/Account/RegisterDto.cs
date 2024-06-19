using System.ComponentModel.DataAnnotations;

namespace BetLembosa_Share_Rooms_BackEnd;

public class RegisterDto
{
  [Required]
  [EmailAddress]
  public string Email { get; set; }

  [Required]
  [StringLength(100)]
  public string FirstName { get; set; }

  [Required]
  [StringLength(100)]
  public string LastName { get; set; }

  [Required]
  [DataType(DataType.Password)]
  public string Password { get; set; }
}
