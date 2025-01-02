using Microsoft.Extensions.DependencyInjection;
using Studio.Extant.HttpProvider;

namespace Studio.Extant.IdentityProvider.Client;

public static class Extensions
{ 
  public static Task<IServiceCollection> EsAddAspIdentityClientProvider(this IServiceCollection serviceCollection)
  {
   
    serviceCollection.AddSingleton<IAspIdentityProvider, AspIdentityProvider>();
    serviceCollection.AddSingleton<IJwtTokenProvider, AspIdentityJwtTokenProvider>();
    serviceCollection.AddSingleton<IAspIdentityJwtTokenProvider, AspIdentityJwtTokenProvider>();

    return Task.FromResult(serviceCollection);
  }
}
