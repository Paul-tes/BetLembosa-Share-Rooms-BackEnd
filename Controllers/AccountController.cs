using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BetLembosa_Share_Rooms_BackEnd;

[Route("api/v1/account")]
public class AccountController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;
  private readonly SignInManager<AppUser> _signInManager;

  public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager) {
    _userManager = userManager;
    _tokenService = tokenService;
    _signInManager = signInManager;
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto loginDto) {
    if (!ModelState.IsValid) return BadRequest(ModelState);

    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == loginDto.Email.ToLower());

    if (user == null) return Unauthorized("Invalid email");

    var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    if (!result.Succeeded) return Unauthorized("Invalid password");

    var token = _tokenService.CreateToken(user);

    return Ok(new { accessToken = token });
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto userDto) {
    try {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var appUser = new AppUser {
        UserName = userDto.FirstName,
        Email = userDto.Email,
        NormalizedUserName = $"{userDto.FirstName} {userDto.LastName}",
      };

      var createdUser = await _userManager.CreateAsync(appUser, userDto.Password);

      if (!createdUser.Succeeded) return StatusCode(500, createdUser.Errors);

      var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

      if (!roleResult.Succeeded) return StatusCode(500, roleResult.Errors);

      var token = _tokenService.CreateToken(appUser);

      return Ok(new { accessToken = token });
    }
    catch (Exception ex) {
      return StatusCode(500, ex.ToString());
    }
  }
  
  [HttpPost("check-user")]
  public async Task<IActionResult> CheckUser([FromBody] CheckUserDto checkUserDto) {
    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == checkUserDto.Email.ToLower());
    return Ok(user != null);
  }

  [Authorize]
  [HttpGet("me")]
  public async Task<IActionResult> Me() {
    // Extract the email claim from the token
    var email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

    if (email == null) return Unauthorized("Can't find email address in token");

    // Find the user by email
    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
    if (user == null) return Unauthorized("User not found");

    return Ok(new {
      email = user.Email,
      userName = user.UserName,
      fullName = user.NormalizedUserName
    });
  }
}
