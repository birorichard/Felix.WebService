using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Felix.WebService.Data.Models.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.DAL.Repositories
{
    public class UserRepository : GenericRepository<FelixDbContext, User>, IUserRepository
    {
        public UserRepository(FelixDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsUserNameUnique(string userName, CancellationToken cancellationToken = default)
        {
            return !await AnyAsync(filter: x => x.UserName == userName && !x.IsDeleted, cancellationToken: cancellationToken);
        }
    }
}
