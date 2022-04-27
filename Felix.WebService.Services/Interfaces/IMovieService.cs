using Felix.WebService.DTO.Movie;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<ICollection<MovieDTO>> GetAll(CancellationToken cancellationToken);
        public Task<MovieDTO> GetById(int id, CancellationToken cancellationToken);
        Task<ICollection<CutDTO>> GetCuts(int id, CancellationToken cancellationToken);
    }
}
