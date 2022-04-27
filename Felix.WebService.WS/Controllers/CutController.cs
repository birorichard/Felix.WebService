using Felix.WebService.DTO.Movie;
using Felix.WebService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.WS.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class CutController : ControllerBase
    {
        private readonly ICutService _cutService;
        private readonly IShotService _shotService;

        public CutController(ICutService cutService, IShotService shotService)
        {
            _cutService = cutService;
            _shotService = shotService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<CutDTO>>> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _cutService.GetAll(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<CutDTO>>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _cutService.GetById(id, cancellationToken));
        }

        [HttpGet("shots/{cutId}")]
        public async Task<ActionResult<ICollection<ShotDTO>>> GetShots([FromRoute] int cutId, CancellationToken cancellationToken = default)
        {
            return Ok(await _shotService.GetShots(cutId, cancellationToken));
        }
    }
}
