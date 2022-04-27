using Felix.WebService.DTO.Movie;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface IShotService
    {
        public Task<ICollection<ShotDTO>> GetShots(int cutId, CancellationToken cancellationToken);
    }
}
