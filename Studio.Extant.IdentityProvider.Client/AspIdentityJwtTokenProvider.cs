using Studio.Extant.HashingProvider;

namespace Studio.Extant.IdentityProvider.Client;

/// <inheritdoc />
public class AspIdentityJwtTokenProvider(IAspIdentityProvider aspIdentityProvider, IHashingProvider hashingProvider) : IAspIdentityJwtTokenProvider
{
  private static DateTime _refreshTime = DateTime.MinValue;
  private static int _tokenLifetime = 0;
  private static string _token = string.Empty;
  private static bool _isLoggedIn = false;

  /// <inheritdoc />
  public bool IsEnabled =>
    true;

  /// <inheritdoc />
  public string TokenType => "Bearer";

  /// <inheritdoc />
  public string Token =>
    _token;

  /// <inheritdoc />
  public bool IsExpired =>
    (DateTime.UtcNow >= _refreshTime.AddSeconds(_tokenLifetime));

  /// <inheritdoc />
  public async Task RefreshTokenAsync(CancellationToken cancellationToken)
  {
    if (!_isLoggedIn)
      throw new Exception("Not logged in");

    await aspIdentityProvider.RefreshTokenAsync(cancellationToken);
  }

  /// <inheritdoc />
  public async Task<(string UserName, string UniqueId)> LoginAsync(string username, string password, CancellationToken cancellationToken)
  {
    var tokenData = await aspIdentityProvider.LoginAsync(username, password, cancellationToken);
    _refreshTime = DateTime.UtcNow;
    _tokenLifetime = tokenData.ExpiresIn;
    _token = tokenData.AccessToken;
    _isLoggedIn = true;

    return (username, hashingProvider.GetHashString(username));
  }
}
