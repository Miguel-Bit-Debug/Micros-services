using System.Security.Claims;

namespace Product.API.Extensions
{
    public static class ClaimTypeExtension
    {
        public static string GetUsernameFromClaim(this ClaimsPrincipal user)
        {
            try
            {
                var username = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                return username;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
