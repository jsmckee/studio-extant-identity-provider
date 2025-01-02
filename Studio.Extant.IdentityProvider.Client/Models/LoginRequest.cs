namespace Studio.Extant.IdentityProvider.Client.Models;

/// <summary>
/// Loging request model.
/// </summary>
/// <param name="email"></param>
/// <param name="password"></param>
/// <param name="twoFactorCode"></param>
/// <param name="twoFactorRecoveryCode"></param>
public sealed record LoginRequest(string email, string password, string twoFactorCode, string twoFactorRecoveryCode);