using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BetLembosa_Share_Rooms_BackEnd;

[Route("api/v1/wishlist")]
[ApiController]
public class WishListController : Controller
{
  private readonly AppDbContext _context;
  private readonly UserManager<AppUser> _userManager;

  public WishListController(AppDbContext context, UserManager<AppUser> userManager) {
    _context = context;
    _userManager = userManager;
  }

  // GET; api/v1/wishlist/getMyLists
  [Authorize]
  [HttpGet("getMyLists")]
  public async Task<ActionResult<ICollection<HomeDto>>> getMyLists() {
    // Extract the email claim from the token
    var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
    if (email == null) return Unauthorized("Can't find email address in token");

    // Find the user by email
    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);

    if (user == null) return Unauthorized("User not found");
    // Retrieve the wish lists of the user

    var wishlists = await _context.Wishlists
      .Where(w => w.UserId == user.Id)
      .Include(w => w.Homes)
      .ToListAsync();
   
    // Project to a collection of HomeDto
    var homeDtos = wishlists.SelectMany(w => w.Homes).Select(home => new HomeDto
    {
        Id = home.Id,
        CreatedAt = home.CreatedAt,
        UpdatedAt = home.UpdatedAt,
        homeType = home.homeType,
        PlaceType = home.PlaceType,
        MapData = home.MapData,
        LocationData = home.LocationData,
        PlaceSpace = home.PlaceSpace,
        PlaceAmenities = home.PlaceAmenities,
        Photos = home.Photos,
        CreatedBy = home.CreatedBy,
        CreatedById = home.CreatedById,
        Title = home.Title,
        Description = home.Description,
        Price = home.Price,
        Rating = home.Rating,
        CommentId = home.CommentId
    }).ToList();
    return Ok(homeDtos);
  }

  // POST: api/v1/wishlist/create
  [Authorize]
  [HttpPost("create")]
  public async Task<ActionResult<WishlistDto>> CreateWishlist([FromBody] CreateWishList createWishlistRequest)
  {
    var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

    if (email == null) return Unauthorized("Can't find email address in token");

    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
    if (user == null) return Unauthorized("User not found");

    var home = await _context.Homes.FirstOrDefaultAsync(h => h.Id == createWishlistRequest.HomeId);
    if (home == null) return NotFound("Home not found");

    var wishlist = new WishlistDto
    {
      Id = Guid.NewGuid(),
      CreatedAt = DateTime.UtcNow,
      UpdatedAt = DateTime.UtcNow,
      UserId = user.Id,
      Homes = new List<HomeDto> { home }
    };

    _context.Wishlists.Add(wishlist);
    await _context.SaveChangesAsync();

    return Ok();
  }

  // DELETE: api/v1/wishlist/delete/{homeId}
  [Authorize]
  [HttpDelete("delete/{homeId}")]
  public async Task<IActionResult> DeleteWishlist(Guid homeId)
  {
    var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

    if (email == null) return Unauthorized("Can't find email address in token");

    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
    if (user == null) return Unauthorized("User not found");

    var wishlist = await _context.Wishlists
      .Include(w => w.Homes)
      .FirstOrDefaultAsync(w => w.UserId == user.Id && w.Homes.Any(h => h.Id == homeId));

    if (wishlist == null) return NotFound("Wishlist or home not found in wishlist");

    var homeToRemove = wishlist.Homes.FirstOrDefault(h => h.Id == homeId);
    if (homeToRemove != null)
    {
      wishlist.Homes.Remove(homeToRemove);
      await _context.SaveChangesAsync();
    }

    return NoContent();
  }


}
