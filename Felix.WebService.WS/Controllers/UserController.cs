using Felix.WebService.Common.Constants;
using Felix.WebService.Common.Exceptions;
using Felix.WebService.DTO.Identity;
using Felix.WebService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.WS.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("change-password"), AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto, CancellationToken cancellationToken = default)
        {
            await _userService.ChangePassword(dto, cancellationToken);
            return Ok();
        }

        [HttpGet, Authorize(Policy = PolicyConstants.AdminOnly)]
        public async Task<ICollection<UserDTO>> GetAll(CancellationToken cancellationToken = default) => await _userService.GetAll(cancellationToken);

        [HttpDelete("{userId}"), Authorize(Policy = PolicyConstants.AdminOnly)]
        public async Task<IActionResult> Delete([FromRoute] int userId, CancellationToken cancellationToken = default) 
        {
            Claim idClaim = HttpContext.User.Claims.First(x => x.Type.Equals("id"));

            _ = int.TryParse(idClaim.Value, out int currentUserId);

            if (currentUserId == userId)
                throw new DeleteOperationForbiddenException();

            await _userService.Delete(userId, cancellationToken);
            return Ok();
        }
    }
}
