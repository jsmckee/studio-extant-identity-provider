namespace Studio.Extant.IdentityProvider.Client.Exceptions;

/// <summary>
/// Refresh Exception, thrown when a refresh attempt fails.
/// </summary>
[Serializable]
public class RefreshException : Exception
{
  public RefreshException(string response) : base($"There was an error logging in: {response}!") { }
}
