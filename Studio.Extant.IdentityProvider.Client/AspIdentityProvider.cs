using Studio.Extant.ConfigurationProvider.EndpointConfiguration;
using Studio.Extant.IdentityProvider.Client.Exceptions;
using Studio.Extant.IdentityProvider.Client.Models;
using System.Text;
using System.Text.Json;

namespace Studio.Extant.IdentityProvider.Client;

/// <inheritdoc />
public class AspIdentityProvider(HttpClient httpClient, IServiceEndpointProvider serviceEndpointProvider) : IAspIdentityProvider
{

  /// <inheritdoc />  
  public async Task<LoginResponse> LoginAsync(string username, string password, CancellationToken cancellationToken)
  {
    var requestContent = new StringContent(JsonSerializer.Serialize(new LoginRequest(username, password, string.Empty, string.Empty)), Encoding.UTF8, "application/json");

    try
    {
      var response = await httpClient.PostAsync($"{await serviceEndpointProvider.Endpoint()}/login", requestContent, cancellationToken);

      if (response.IsSuccessStatusCode)
      {
        var responseContent = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        return tokenResponse ?? throw new Exception("Failed to login");
      }
      else
        throw new LoginException(await response.Content.ReadAsStringAsync());
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  /// <inheritdoc />  
  public async Task RefreshTokenAsync(CancellationToken cancellationToken) =>
    throw new NotImplementedException();
}
