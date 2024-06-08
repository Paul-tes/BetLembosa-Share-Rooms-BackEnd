using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BetLembosa_Share_Rooms_BackEnd;

[Route("api/v1/account")]
public class AccountController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;
  private readonly SignInManager<AppUser> _signinManager;

  public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager) {
    _userManager = userManager;
    _tokenService = tokenService;
    _signinManager = signInManager;
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginDto loginDto) {
    if(!ModelState.IsValid) return BadRequest(ModelState);

    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

    if(user == null) return Unauthorized("Invalid User Name");

    var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    if(!result.Succeeded) return Unauthorized("Username");

    return Ok(
      new NewUserDto{
        UserName = user.UserName,
        Email = user.Email,
        Token = _tokenService.CreateToken(user),
      }
    );
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto userDto) {
    try {
      if(!ModelState.IsValid) return  BadRequest(ModelState);
      var appUser = new AppUser{
        UserName = userDto.FirstName,
        NormalizedUserName = $"{userDto.FirstName}  {userDto.LastName}".ToUpper(),
        Email = userDto.Email
      };

      var createdUser = await _userManager.CreateAsync(appUser, userDto.Password);

      if(createdUser.Succeeded) {
        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
        if(roleResult.Succeeded) {
          return Ok(
            new NewUserDto {
              UserName = appUser.UserName,
              Email = appUser.Email,
              Token = _tokenService.CreateToken(appUser),
            }
          );
        } else {
          return StatusCode(500, roleResult.Errors.ToString());
        }
      } else {
        return StatusCode(500, createdUser.Errors.ToString());
      }
    }
    catch (Exception ex) {
      return StatusCode(500, ex.ToString());
    }
  }

}
