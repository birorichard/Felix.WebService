using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Felix.WebService.Data.Models;

namespace Felix.WebService.DAL.Repositories
{
    public class SeedRepository : GenericRepository<FelixDbContext, Seed>, ISeedRepository
    {
        public SeedRepository(FelixDbContext dbContext) : base(dbContext)
        {
        }
    }
}
