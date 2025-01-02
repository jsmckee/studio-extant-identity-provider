namespace Studio.Extant.IdentityProvider.Client.Exceptions;

/// <summary>
/// Login Exception, thrown when a login attempt fails.
/// </summary>
[Serializable]
public class LoginException : Exception
{
  public LoginException(string response) : base($"There was an error logging in: {response}!") { }
}
