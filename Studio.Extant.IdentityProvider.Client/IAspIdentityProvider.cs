using Studio.Extant.IdentityProvider.Client.Models;

namespace Studio.Extant.IdentityProvider.Client;

/// <summary>
/// Provider to authenticate with ASP.NET Identity.
/// </summary>
public interface IAspIdentityProvider
{
  /// <summary>
  /// Login to ASP.NET Identity.
  /// </summary>
  /// <param name="username"></param>
  /// <param name="password"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task<LoginResponse> LoginAsync(string username, string password, CancellationToken cancellationToken);

  /// <summary>
  /// Get a refreshed Token.
  /// </summary>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task RefreshTokenAsync(CancellationToken cancellationToken);
}
