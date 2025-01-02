using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Studio.Extant.IdentityProvider.Database;

public class IdentityDatabaseDesignTimeFactory : IDesignTimeDbContextFactory<IdentityDatabase>
{
    public IdentityDatabase CreateDbContext(string[] args) =>
      new(new DbContextOptionsBuilder<IdentityDatabase>().UseSqlServer("Data Source=(localdb)\\MSSqlLocalDb;Initial Catalog=DesignDataProtection;Integrated Security=True;").Options);
}
