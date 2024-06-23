using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BetLembosa_Share_Rooms_BackEnd;

[Route("api/v1/home")]
[ApiController]
public class HomeController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly UserManager<AppUser> _userManager;

  public HomeController(AppDbContext context, UserManager<AppUser> userManager)
  {
    _context = context;
    _userManager = userManager;
  }

  // GET: api/home
  [HttpGet("getHomes")]
  public async Task<ActionResult<IEnumerable<HomeDto>>> GetHomes()
  {
    return await _context.Homes.ToListAsync();
  }

  // GET: api/v1/home/5
  [Authorize]
  [HttpGet("getHome")]
  public async Task<ActionResult<HomeDto>> getHome(Guid id)
  {
    var home = await _context.Homes.FindAsync(id);

    if (home == null)
    {
      return NotFound();
    }

    return home;
  }

  // PUT: api/home/5
  [Authorize]
  [HttpPut("update")]
  public async Task<IActionResult> Update(Guid id, HomeDto homeDto)
  {
    if (id != homeDto.Id)
    {
      return BadRequest();
    }

    homeDto.UpdatedAt = DateTime.UtcNow;
    _context.Entry(homeDto).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!HomeDtoExists(id))
      {
          return NotFound();
      }
      else
      {
          throw;
      }
    }

    return NoContent();
  }

  // POST: api/home/create
  [Authorize]
  [HttpPost("create")]
  public async Task<ActionResult<HomeDto>> Create(CreateHomeDto createHomeDto)
  {
    // Extract the email claim from the token
    var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

    if (email == null) return Unauthorized("Can't find email address in token");

    // Find the user by email
    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
    if (user == null) return Unauthorized("User not found");

    var homeDto = new HomeDto
    {
      Id = Guid.NewGuid(),
      CreatedAt = DateTime.UtcNow,
      UpdatedAt = DateTime.UtcNow,
      homeType = createHomeDto.homeType,
      PlaceType = createHomeDto.PlaceType,
      MapData = createHomeDto.MapData,
      LocationData = createHomeDto.LocationData,
      PlaceSpace = createHomeDto.PlaceSpace,
      PlaceAmenities = createHomeDto.PlaceAmenities,
      Photos = createHomeDto.Photos,
      Title = createHomeDto.Title,
      Description = createHomeDto.Description,
      Price = createHomeDto.Price,
      CreatedBy = user.NormalizedUserName,
      CreatedById = user.Id,
    };
    _context.Homes.Add(homeDto);
    await _context.SaveChangesAsync();
    return Ok(homeDto);
  }

  [Authorize]
  [HttpGet("GetMyHomes")]
  public async Task<ActionResult<IEnumerable<HomeDto>>> GetMyHomes()
  {
    // Extract the email claim from the token
    var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

    if (email == null) return Unauthorized("Can't find email address in token");

    // Find the user by email
    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
    if (user == null) return Unauthorized("User not found");

    // Query the database for homes created by the user
    var homes = await _context.Homes
        .Where(h => h.CreatedById == user.Id)
        .ToListAsync();

    return Ok(homes);
  }


  // DELETE: api/v1/home/5
  [Authorize]
  [HttpDelete("delete")]
  public async Task<IActionResult> Delete(Guid id)
  {
    // Extract the email claim from the token
    var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

    if (email == null) return Unauthorized("Can't find email address in token");

    // Find the user by email
    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
    if (user == null) return Unauthorized("User not found");

    // Find the home by id
    var home = await _context.Homes.FindAsync(id);
    if (home == null)
    {
        return NotFound();
    }

    // Check if the user is the owner of the home
    if (home.CreatedById != user.Id)
    {
        return Forbid("You are not authorized to delete this home.");
    }

    // Delete the home
    _context.Homes.Remove(home);
    await _context.SaveChangesAsync();

    return NoContent();
  }


  private bool HomeDtoExists(Guid id)
  {
    return _context.Homes.Any(e => e.Id == id);
  }
}