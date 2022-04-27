using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Felix.WebService.Data.Models.Movie;

namespace Felix.WebService.DAL.Repositories
{
    public class CutRepository : GenericRepository<FelixDbContext, Cut>, ICutRepository
    {
        public CutRepository(FelixDbContext dbContext) : base(dbContext)
        {
        }
    }
}
