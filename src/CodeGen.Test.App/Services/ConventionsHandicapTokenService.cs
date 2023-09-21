using ConventionsHandicap.Shared;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Anabasis.Identity;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.App.Shared;
using System.Linq;

namespace ConventionsHandicap.Services
{

    public class ConventionsHandicapTokenService : IJwtTokenService<ConventionsHandicapUser>
    {
        private const double EXPIRY_DURATION_MINUTES = 7 * 24 * 60;

        public ConventionsHandicapTokenService()
        {
        }

        public (string token, DateTime expirationUtcDate) CreateToken(ConventionsHandicapUser user, params Claim[] additionalClaims)
        {
            var claims = new[] {
            new Claim("jti", $"{user.UserId}"),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.NameIdentifier, $"{user.UserId}")
        };

            claims = claims.Concat(additionalClaims).DistinctBy(claim => claim.Type).ToArray();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Consts.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expirationUtcDate = DateTime.UtcNow.AddMinutes(EXPIRY_DURATION_MINUTES);
            var tokenDescriptor = new JwtSecurityToken(claims: claims,
                expires: expirationUtcDate, signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return (token, expirationUtcDate);
        }
        public (bool isUserValid, SecurityToken securityToken) GetSecurityTokenFromString(string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(Consts.JwtKey);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = mySecurityKey,
                    ClockSkew = TimeSpan.Zero,
                    LifetimeValidator = (DateTime? notBefore, 
                    DateTime? expires, 
                    SecurityToken securityToken,
                    TokenValidationParameters validationParameters) =>
                    {
                        return notBefore <= DateTime.UtcNow &&
                               expires > DateTime.UtcNow;
                    }
                }, out SecurityToken validatedToken);

                return (true, validatedToken);
            }
            catch
            {
                return (false, null);
            }
        }
    }
}
