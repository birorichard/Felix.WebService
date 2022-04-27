using Felix.WebService.DTO.Movie;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface ICutService
    {
        public Task<ICollection<CutDTO>> GetAll(CancellationToken cancellationToken);
        public Task<CutDTO> GetById(int id, CancellationToken cancellationToken);
    }
}
