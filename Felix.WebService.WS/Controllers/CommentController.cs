using Felix.WebService.DTO.Comment;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("create-from-dto")]
        public async Task<IActionResult> CreateFromCommentDTO(CommentDTO dto, CancellationToken cancellationToken = default)
        {
            await _commentService.CreateCommentFromCommentDTO(dto, cancellationToken);
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCommentDTO dto, CancellationToken cancellationToken = default)
        {
            await _commentService.CreateComment(dto, cancellationToken);
            return Ok();
        }

        [HttpGet("cut/{cutId}")]
        public async Task<ActionResult<List<CommentDTO>>> GetComments([FromRoute] int cutId, CancellationToken cancellationToken = default)
        {
            return Ok(await _commentService.GetComments(cutId, cancellationToken));
        }

        [HttpPatch]
        public async Task<IActionResult> Update(CommentDTO dto, CancellationToken cancellationToken = default)
        {
            await _commentService.UpdateComment(dto, cancellationToken);
            return Ok();
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete([FromRoute] int commentId, CancellationToken cancellationToken = default)
        {
            Claim idClaim = HttpContext.User.Claims.First(x => x.Type.Equals("id"));
            if (idClaim is null)
                return Unauthorized();

            _ = int.TryParse(idClaim.Value, out int userId);
            
            await _commentService.Delete(userId, commentId, cancellationToken);
            return Ok();
        }
    }
}
