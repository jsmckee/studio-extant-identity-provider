using Microsoft.AspNetCore.Identity;
using Studio.Extant.IdentityProvider.Database;

namespace Studio.Extant.IdentityProvider;

/// <summary>
/// Provider to seed the database with default data.
/// </summary>
public interface IDataSeedProvider
{
  /// <summary>
  /// Seed the data.
  /// </summary>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public Task SeedAsync(CancellationToken cancellationToken);
}

/// <inheritdoc />
internal sealed class DataSeedProvider(IIdentityDatabase identityDatabase, UserManager<IdentityUser> userManager) : IDataSeedProvider
{

  /// <inheritdoc />
  public async Task SeedAsync(CancellationToken cancellationToken)
  {
    if (!identityDatabase.Users.Any())
    {
      Debug.WriteLine("Seeding database with default data...");
      await userManager.CreateAsync(new IdentityUser()
      {
        Id = Guid.NewGuid().ToString(),
        UserName = "admin",
        NormalizedUserName = "ADMIN",
        Email = "admin@craqk.extant.studio",
        NormalizedEmail = "ADMIN@CRAQK.EXTANT.STUDIO",
        EmailConfirmed = false,
        PasswordHash = "",
        SecurityStamp = "",
        ConcurrencyStamp = "",
        PhoneNumberConfirmed = false,
        TwoFactorEnabled = false,
        LockoutEnabled = false,
        AccessFailedCount = 0
      });

      var defaultUser = identityDatabase.Users.FirstOrDefault();

      if (defaultUser != null)
      {
        var token = userManager.GeneratePasswordResetTokenAsync(defaultUser).Result;

        await userManager.ResetPasswordAsync(defaultUser, token, "forNoMan1!");
      }
    }
  }
}
