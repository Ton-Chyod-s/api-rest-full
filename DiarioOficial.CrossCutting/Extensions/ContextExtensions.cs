using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace DiarioOficial.CrossCutting.Extensions
{
    public static class ContextExtensions
    {
        public static string GetTokenByContext(this HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.TryGetValue("Authorization", out StringValues authHeaders))
                return string.Empty;

            return authHeaders.FirstOrDefault()?.Split(" ").Last() ?? string.Empty;
        }

        public static string GetSystemIdentifierIdByContext(this HttpContext httpContext)
        {
            string token = httpContext.GetTokenByContext();

            if (string.IsNullOrWhiteSpace(token))
                return string.Empty;

            return GetTokenIdentifierClaim(token);
        }

        private static string GetTokenIdentifierClaim(string token)
        {
            var claims = DeserializeJwtToken(token);

            if (claims == null || claims.Length == 0) return string.Empty;

            string? identifier = claims.FirstOrDefault(claim => claim.Type == "nameid")?.Value;

            if (string.IsNullOrEmpty(identifier)) return string.Empty;

            return identifier;
        }

        private static Claim[]? DeserializeJwtToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);
            IEnumerable<Claim> claims = jwtToken.Claims;

            return claims.ToArray();
        }
    }
}
