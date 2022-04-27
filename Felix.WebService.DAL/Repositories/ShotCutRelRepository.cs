using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Felix.WebService.Data.Models.Movie;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.DAL.Repositories
{
    public class ShotCutRelRepository : GenericRepository<FelixDbContext, ShotCutRel>, IShotCutRelRepository
    {
        public ShotCutRelRepository(FelixDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Shot>> GetShotsAsync(int cutId, CancellationToken cancellationToken)
        {
            return await _table.Include(x => x.Cut).Where(x => x.CutId == cutId).Select(x => x.Shot).ToListAsync(cancellationToken);
        }
    }
}
