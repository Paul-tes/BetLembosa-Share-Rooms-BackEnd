using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetLembosa_Share_Rooms_BackEnd;

public class AppDbContext : IdentityDbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

}
