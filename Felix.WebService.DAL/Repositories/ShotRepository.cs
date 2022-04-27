using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Felix.WebService.Data.Models.Movie;

namespace Felix.WebService.DAL.Repositories
{
    public class ShotRepository : GenericRepository<FelixDbContext, Shot>, IShotRepository
    {
        public ShotRepository(FelixDbContext dbContext) : base(dbContext)
        {
        }
    }
}
