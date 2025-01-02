using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Studio.Extant.IdentityProvider.Database;

namespace Studio.Extant.IdentityProvider;

public static class Extensions
{
  public static Task<IServiceCollection> EsAddAspIdentityServiceProvider(this IServiceCollection serviceCollection, string connectionString)
  {
    const int _lockout = 15;

    if (serviceCollection.Any(serviceDescriptor => serviceDescriptor.ServiceType == typeof(IDataSeedProvider)))
      return Task.FromResult(serviceCollection);

    serviceCollection.TryAddTransient<IDataSeedProvider, DataSeedProvider>();
    serviceCollection.AddDbContext<IIdentityDatabase, IdentityDatabase>(o => o.UseSqlServer(connectionString));
    serviceCollection.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<IdentityDatabase>();
    using var dbProvider = serviceCollection.BuildServiceProvider();

    dbProvider.GetRequiredService<IdentityDatabase>().Database.Migrate();

    serviceCollection.Configure<IdentityOptions>(options =>
    {
      // Password settings.
      options.Password.RequireDigit = true;
      options.Password.RequireLowercase = true;
      options.Password.RequireNonAlphanumeric = true;
      options.Password.RequireUppercase = true;
      options.Password.RequiredLength = 6;
      options.Password.RequiredUniqueChars = 1;

      // Lockout settings.
      options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(_lockout);
      options.Lockout.MaxFailedAccessAttempts = 5;
      options.Lockout.AllowedForNewUsers = true;

      // User settings.
      options.User.AllowedUserNameCharacters =
          "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
      options.User.RequireUniqueEmail = false;
    });
    
    serviceCollection.ConfigureApplicationCookie(options =>
    {
      // Cookie settings
      options.Cookie.HttpOnly = false;
      options.ExpireTimeSpan = TimeSpan.FromMinutes(_lockout);
      options.SlidingExpiration = true;
    });

    return Task.FromResult(serviceCollection);
  }

  
}
