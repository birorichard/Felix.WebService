using Felix.WebService.DTO.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface ITokenService
    {
        TokenDTO GenerateAccessToken(ClaimsPrincipal claimsPrincipal);
        Task<TokenDTO> RefreshToken(string refreshToken, CancellationToken cancellationToken);
    }
}
