using Felix.WebService.Common.Constants;
using Felix.WebService.DTO.Authentication;
using Felix.WebService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.WS.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthenticationService authenticationService, ITokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<TokenDTO>> Login([FromBody] LoginDTO dto, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            ClaimsPrincipal claimsPrincipal = await _authenticationService.Authenticate(dto, cancellationToken);

            TokenDTO token = _tokenService.GenerateAccessToken(claimsPrincipal);

            return Ok(token);
        }

        [HttpPost("register"), Authorize(Policy = PolicyConstants.AdminOnly)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _authenticationService.Register(dto, cancellationToken);

            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenDTO>> RefreshToken([FromBody] string refreshToken, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            TokenDTO token = await _tokenService.RefreshToken(refreshToken, cancellationToken);

            return Ok(token);
        }
    }
}
