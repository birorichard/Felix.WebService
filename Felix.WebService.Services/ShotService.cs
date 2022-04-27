using AutoMapper;
using Felix.WebService.DAL;
using Felix.WebService.DTO.Movie;
using Felix.WebService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services
{
    public class ShotService : IShotService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShotService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ICollection<ShotDTO>> GetShots(int cutId, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<ShotDTO>>(await _unitOfWork.ShotCutRelRepository.GetShotsAsync(cutId, cancellationToken));
        }
    }
}
