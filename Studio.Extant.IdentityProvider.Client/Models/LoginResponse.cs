namespace Studio.Extant.IdentityProvider.Client.Models;

/// <summary>
/// Login response model.
/// </summary>
/// <param name="TokenType"></param>
/// <param name="AccessToken"></param>
/// <param name="ExpiresIn"></param>
/// <param name="RefreshToken"></param>
public sealed record LoginResponse(string TokenType, string AccessToken, int ExpiresIn, string RefreshToken);