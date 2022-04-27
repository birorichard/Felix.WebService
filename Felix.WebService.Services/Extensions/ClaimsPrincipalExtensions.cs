using Felix.WebService.Common.Constants;
using Felix.WebService.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Extensions
{
    
    public static class ClaimsPrincipalExtensions
    {
        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));

            Claim idClaim = claimsPrincipal.FindFirst(x => string.Equals(x.Type, "id", StringComparison.CurrentCultureIgnoreCase));

            if (idClaim == null)
                throw new KeyNotFoundException("in: ClaimsPrincipalExtensions.GetId");

            return int.TryParse(idClaim.Value, out int id) ? id : throw new InvalidCastException($"ClaimsPrincipalExtensions.GetId: {idClaim.Value}");
        }

        public static Task<ClaimsPrincipal> ToClaimsPrincipalAsync(this User user, CancellationToken cancellationToken = default)
        {
            ClaimsIdentity claimsIdentity = new();
            List<Claim> claimsToAdd = new()
            {
                new(ClaimConstants.IdKey, user.Id.ToString()),
                new(ClaimConstants.UserNameKey, user.UserName),
                new(ClaimConstants.IsAdminKey, user.IsAdmin ? ClaimConstants.TrueValue : ClaimConstants.FalseValue),
            };
            
            claimsIdentity.AddClaims(claimsToAdd);

            return Task.FromResult(new ClaimsPrincipal(claimsIdentity));
        }
    }
}
