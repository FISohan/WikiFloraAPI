using System.Security.Claims;
using WikiFloraAPI.Models;

namespace WikiFloraAPI.Services
{
    public class ClaimService
    {
        public static ClaimData getClaimData(IEnumerable<Claim> claim)
        {
          string sub =  claim.FirstOrDefault(c => c.Type.Equals("sub"))!.Value;
          string name = claim.FirstOrDefault(c => c.Type.Equals("name"))!.Value;
          return new ClaimData { name = name, sub = sub };
        }
    }
}
