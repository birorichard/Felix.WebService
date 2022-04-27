using Felix.WebService.Common.ConfigurationOptions;
using Felix.WebService.Common.Exceptions.Api;
using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data.Models.Identity;
using Felix.WebService.DTO.Authentication;
using Felix.WebService.Services.Extensions;
using Felix.WebService.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly SigningCredentials _credentials;
        private readonly IUserRepository _userRepository;
        private readonly SymmetricSecurityKey _securityKey;

        public TokenService(IOptions<JwtOptions> jwtOptions, IUserRepository userRepository)
        {
            _jwtOptions = jwtOptions.Value;
            _securityKey = new(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            _credentials = new(_securityKey, SecurityAlgorithms.HmacSha256);
            _userRepository = userRepository;
        }

        private string CreateJwtToken(ClaimsPrincipal claimsPrincipal, DateTime expiration)
        {
            if (claimsPrincipal.Identity is not ClaimsIdentity identity)
                throw new Exception();

            SecurityTokenDescriptor descriptor = new()
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                IssuedAt = DateTime.Now,
                Expires = expiration,
                SigningCredentials = _credentials,
                Subject = identity
            };

            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(descriptor);

            return tokenHandler.WriteToken(token);
        }

        public TokenDTO GenerateAccessToken(ClaimsPrincipal claimsPrincipal)
        {
            DateTime accessTokenExpirationDate = DateTime.Now.AddMinutes(_jwtOptions.LifeTimeInMinutes);
            return new TokenDTO()
            {
                Token = CreateJwtToken(claimsPrincipal, accessTokenExpirationDate),
                Expires = accessTokenExpirationDate,
                RefreshToken = CreateJwtToken(claimsPrincipal, DateTime.Now.AddMinutes(_jwtOptions.RefreshTokenLifeTimeInMinutes))
            };
        }

        public async Task<TokenDTO> RefreshToken(string refreshToken, CancellationToken cancellationToken = default)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            tokenHandler.ValidateToken(refreshToken, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = _securityKey
            }, out SecurityToken validatedToken);

            ClaimsPrincipal oldClaimsPrincipal = new(new ClaimsIdentity(((JwtSecurityToken)validatedToken).Claims));

            User user = _userRepository.SingleOrDefault(filter: x => x.UserName == oldClaimsPrincipal.FindFirstValue("userName"));

            if (user == null)
            {
                throw new UnauthorizedException();
            }

            ClaimsPrincipal newClaimsPrincipal = await user.ToClaimsPrincipalAsync(cancellationToken);

            DateTime accessTokenExpirationDate = DateTime.Now.AddMinutes(_jwtOptions.LifeTimeInMinutes);
            return new TokenDTO()
            {
                Token = CreateJwtToken(newClaimsPrincipal, accessTokenExpirationDate),
                Expires = accessTokenExpirationDate,
                RefreshToken = CreateJwtToken(newClaimsPrincipal, DateTime.Now.AddMinutes(_jwtOptions.RefreshTokenLifeTimeInMinutes))
            };
        }
    }
}