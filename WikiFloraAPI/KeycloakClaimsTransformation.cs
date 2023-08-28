using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace WikiFloraAPI
{
    public class KeycloakClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {

            ClaimsPrincipal result = principal.Clone();
            ClaimsIdentity identity = new ClaimsIdentity();

            var realmAccessValue = principal.FindFirst("realm_access")?.Value;
            if (string.IsNullOrWhiteSpace(realmAccessValue)) return Task.FromResult(result);
            var realmAccess = JsonDocument.Parse(realmAccessValue);
            var realmRole = realmAccess.RootElement.GetProperty("roles");

            foreach (var value in realmRole.EnumerateArray().Select(role => role.GetString()).Where(value => !string.IsNullOrWhiteSpace(value)))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, value!));
            }
            principal.AddIdentity(identity);

            return Task.FromResult(principal);
        }
    }
}
