using Felix.WebService.DTO.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ClaimsPrincipal> Authenticate(LoginDTO dto, CancellationToken cancellationToken);
        Task Register(RegisterDTO dto, CancellationToken cancellationToken);
    }
}
