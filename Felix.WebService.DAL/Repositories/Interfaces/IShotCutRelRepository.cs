using Felix.WebService.Data.Models.Movie;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.DAL.Repositories.Interfaces
{
    public interface IShotCutRelRepository : IGenericRepository<ShotCutRel>
    {
        public Task<ICollection<Shot>> GetShotsAsync(int cutId, CancellationToken cancellationToken);
    }
}
