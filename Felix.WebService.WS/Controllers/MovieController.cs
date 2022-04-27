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
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ICollection<MovieDTO>>> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _movieService.GetAll(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<MovieDTO>>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _movieService.GetById(id, cancellationToken));
        }

        [HttpGet("{id}/cuts")]
        public async Task<ActionResult<ICollection<CutDTO>>> GetCuts([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _movieService.GetCuts(id, cancellationToken));
        }
    }
}
