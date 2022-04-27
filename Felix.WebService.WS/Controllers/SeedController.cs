using Felix.WebService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.WS.Controllers
{
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ISeedService _seedService;

        public SeedController(ISeedService seedService)
        {
            _seedService = seedService;
        }

        [HttpPost]
        public async Task<IActionResult> Seed(CancellationToken cancellationToken = default)
        {
            await _seedService.SeedAll(cancellationToken);
            return Ok();
        }
    }
}
