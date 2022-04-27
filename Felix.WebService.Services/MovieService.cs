using AutoMapper;
using Felix.WebService.DAL;
using Felix.WebService.DTO.Movie;
using Felix.WebService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services
{
    public class MovieService : IMovieService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<MovieDTO>> GetAll(CancellationToken cancellationToken) => 
            _mapper.Map<ICollection<MovieDTO>>(await _unitOfWork.MovieRepository.GetAsync(cancellationToken: cancellationToken));

        public async Task<MovieDTO> GetById(int id, CancellationToken cancellationToken) => 
            _mapper.Map<MovieDTO>(await _unitOfWork.MovieRepository.GetByIdAsync(id: id, cancellationToken: cancellationToken));

        public async Task<ICollection<CutDTO>> GetCuts(int id, CancellationToken cancellationToken) => 
            _mapper.Map<ICollection<CutDTO>>(await _unitOfWork.CutRepository.GetAsync(filter: x => x.MovieId == id, include: x => x.Include(y => y.Movie).Include(y => y.ShotCutRels).ThenInclude(z => z.Shot), cancellationToken: cancellationToken));
    }
}
