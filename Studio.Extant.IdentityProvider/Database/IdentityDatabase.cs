using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Studio.Extant.IdentityProvider.Database;

public class IdentityDatabase : IdentityDbContext<IdentityUser>, IIdentityDatabase
{
  public IdentityDatabase(DbContextOptions<IdentityDatabase> options) :
      base(options)
  { }
}