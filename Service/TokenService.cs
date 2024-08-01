using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BetLembosa_Share_Rooms_BackEnd;

public class TokenService : ITokenService
{
  private readonly IConfiguration _config;
  private readonly SymmetricSecurityKey _key;
  public TokenService(IConfiguration config) {
    _config = config;
    _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigninKey"]));
  }
  public string CreateToken(AppUser user)
  {
    var claims = new List<Claim>{
      new Claim(JwtRegisteredClaimNames.Email, user.Email),
      new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
    };

    var creads = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
    var tokenDiscriptor = new SecurityTokenDescriptor{
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.Now.AddDays(7),
      SigningCredentials = creads,
      Issuer = _config["JWT:Issuer"],
      Audience = _config["JWT:Audience"],
    };

    var tokenHandler = new JwtSecurityTokenHandler();

    var token = tokenHandler.CreateToken(tokenDiscriptor);

    return tokenHandler.WriteToken(token);
  }
}
