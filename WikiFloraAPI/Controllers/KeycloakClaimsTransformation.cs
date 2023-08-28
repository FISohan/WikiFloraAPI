using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace WikiFloraAPI.Controllers
{
    public class KeycloakClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsPrincipal result = principal.Clone();

            if (result.Identities is not ClaimsIdentity identity) return Task.FromResult(result);
            var nameValue = principal.FindFirst("name")?.Value;
            if(!string.IsNullOrWhiteSpace(nameValue))identity.AddClaim(new Claim(ClaimTypes.Name, nameValue));

            var emailValue = principal.FindFirst("email")?.Value;
            if (!string.IsNullOrWhiteSpace(emailValue)) identity.AddClaim(new Claim(ClaimTypes.Email, emailValue));

            var sub = principal.FindFirst("sub")?.Value;
            if (!string.IsNullOrWhiteSpace(sub)) identity.AddClaim(new Claim(ClaimTypes.Sid, sub));

            var realmAccessValue = principal.FindFirst("realm_access")?.Value;
            if(string.IsNullOrWhiteSpace(realmAccessValue))return Task.FromResult(result);

            var realmAccess = JsonDocument.Parse(realmAccessValue);
            var realmRole = realmAccess.RootElement.GetProperty("roles");

            foreach(var value in realmRole.EnumerateArray().Select(role => role.GetString()).Where(value => !string.IsNullOrWhiteSpace(value)))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, value!));
            }
            return Task.FromResult(principal);
        }
    }
}
