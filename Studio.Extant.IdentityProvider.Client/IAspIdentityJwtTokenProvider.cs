using Studio.Extant.HttpProvider;

namespace Studio.Extant.IdentityProvider.Client;

/// <summary>
/// Implementation for the Asp Identity server.
/// </summary>
public interface IAspIdentityJwtTokenProvider : IJwtTokenProvider
{
  /// <summary>
  /// Log in with a simple username and password.
  /// </summary>
  /// <param name="username"></param>
  /// <param name="password"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  Task<(string UserName, string UniqueId)> LoginAsync(string username, string password, CancellationToken cancellationToken);
}
