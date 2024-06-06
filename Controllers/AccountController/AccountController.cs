using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BetLembosa_Share_Rooms_BackEnd;

[Route("api/v1/account")]
public class AccountController : ControllerBase
{
  private readonly UserManager<IdentityUser> _userManager;
  private readonly ITokenService _tokenService;

  public AccountController(UserManager<IdentityUser> userManager, ITokenService tokenService) {
    _userManager = userManager;
    _tokenService = tokenService;
  }

  [HttpPost("login")]

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto userDto) {
    try {
      if(!ModelState.IsValid) return  BadRequest(ModelState);
      var appUser = new IdentityUser{
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
