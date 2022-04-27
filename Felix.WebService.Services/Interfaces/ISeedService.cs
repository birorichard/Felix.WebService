using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface ISeedService
    {
        Task SeedAll(CancellationToken cancellationToken = default);
    }
}
