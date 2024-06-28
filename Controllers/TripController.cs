using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace BetLembosa_Share_Rooms_BackEnd;

[ApiController]
[Route("api/v1/trip")]
public class TripController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public TripController(IConfiguration configuration, AppDbContext context, UserManager<AppUser> userManager) {
        _configuration = configuration;
        _context = context;
        _userManager = userManager;
    }

    // Extract email and user from token
    private async Task<AppUser> GetUserFromToken() {
        var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
        if (email == null) throw new UnauthorizedAccessException("Can't find email address in token");
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null) throw new UnauthorizedAccessException("User not found");
        return user;
    }

    [Authorize]
    [HttpPost("create-checkout-session")]
    public async Task<ActionResult<CheckoutOrderResponse>> CreateCheckoutSession([FromBody] CheckoutDto data) {
      var options = new Stripe.Checkout.SessionCreateOptions {
        SuccessUrl = data.SuccessUrl,
        CancelUrl = data.CancelUrl,
        PaymentMethodTypes = new List<string> {
            "card"
        },
        LineItems = new List<SessionLineItemOptions> {
            new() {
                PriceData = new SessionLineItemPriceDataOptions {
                    UnitAmount = (long)data.Price * 100,
                    Currency = "USD",
                    ProductData = new SessionLineItemPriceDataProductDataOptions {
                        Name = data.HostName,
                        Description = $"{data.StartDate} Upto {data.EndDate}",
                        Images = new List<string> { data.HostPhoto }
                    },
                },
                Quantity = 1,
            },
        },
        Mode = "payment"
      };

      var service = new Stripe.Checkout.SessionService();
      var session = await service.CreateAsync(options);

      // Create a trip after session is created
      var TripId = await CreateTrip(data);

      var response = new CheckoutOrderResponse {
        SessionId = session.Id,
        TripId = TripId,
      };

      return Ok(response);
    }

    [Authorize]
    [HttpPost("create")]
    private async Task<Guid> CreateTrip(CheckoutDto data) {
      var user = await GetUserFromToken();
      var trip = new TripDto {
        Id = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        UserId = user.Id,
        HomeId = data.HostId,
        StartDate = data.StartDate,
        EndDate = data.EndDate,
        HostName = data.HostName,
        Photo = data.HostPhoto,
        Paid = false,
      };

      _context.Trips.Add(trip);
      await _context.SaveChangesAsync();

      return trip.Id;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrip(Guid id) {
        var trip = await _context.Trips.FindAsync(id);

        if (trip == null) {
            return NotFound();
        }

        return Ok(trip);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrip(Guid id) {
        var trip = await _context.Trips.FindAsync(id);

        if (trip == null) {
            return NotFound();
        }

        _context.Trips.Remove(trip);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [Authorize]
    [HttpPut("updatePayment/{id}")]
    public async Task<IActionResult> UpdatePayment(Guid id, [FromBody] bool paid) {
        var trip = await _context.Trips.FindAsync(id);

        if (trip == null) {
            return NotFound();
        }

        trip.Paid = paid;
        trip.UpdatedAt = DateTime.UtcNow;

        _context.Entry(trip).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [Authorize]
    [HttpGet("getAllTrips")]
    public async Task<IActionResult> GetAllTripsForUser() {
        var user = await GetUserFromToken();
        var trips = await _context.Trips.Where(t => t.UserId == user.Id).ToListAsync();

        return Ok(trips);
    }
}
