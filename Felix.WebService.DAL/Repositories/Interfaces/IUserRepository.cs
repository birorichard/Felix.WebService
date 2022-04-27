using Felix.WebService.Data.Models.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsUserNameUnique(string userName, CancellationToken cancellationToken = default);
    }
}
