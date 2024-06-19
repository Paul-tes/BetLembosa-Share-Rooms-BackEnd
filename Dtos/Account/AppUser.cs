using Microsoft.AspNetCore.Identity;

namespace BetLembosa_Share_Rooms_BackEnd;

public class AppUser : IdentityUser
{

  public ICollection<HomeDto> Homes { get; set; }
  public ICollection<WishlistDto> Wishlists { get; set; }
  public ICollection<TripDto> Trips { get; set; }
}
