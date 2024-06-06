using Microsoft.AspNetCore.Identity;

namespace BetLembosa_Share_Rooms_BackEnd;

public interface ITokenService
{
  string CreateToken(IdentityUser user);
}

