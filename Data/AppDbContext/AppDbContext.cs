using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetLembosa_Share_Rooms_BackEnd;

public class AppDbContext : IdentityDbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

  // all models sets here
  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);
    List<IdentityRole> roles = new List<IdentityRole>{
      new IdentityRole{
        Name = "Admin",
        NormalizedName = "ADMIN"
      },
      new IdentityRole{
        Name = "User",
        NormalizedName = "USER"
      }
    };
    builder.Entity<IdentityRole>().HasData(roles);
  }

}
