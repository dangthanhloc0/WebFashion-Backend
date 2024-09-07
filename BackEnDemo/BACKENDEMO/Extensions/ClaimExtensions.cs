using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BACKENDEMO.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            if (user == null || !user.Identity.IsAuthenticated)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null or unauthenticated.");
            }

            var givenNameClaim = user.Claims.SingleOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givename");
            return givenNameClaim?.Value ?? string.Empty;
        }
    }
}