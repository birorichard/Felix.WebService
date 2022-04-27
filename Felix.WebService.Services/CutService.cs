using AutoMapper;
using Felix.WebService.DAL;
using Felix.WebService.DTO.Movie;
using Felix.WebService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services
{
    public class CutService : ICutService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CutService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ICollection<CutDTO>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<CutDTO>>(await _unitOfWork.CutRepository.GetAsync(cancellationToken: cancellationToken));
        }

        public async Task<CutDTO> GetById(int id, CancellationToken cancellationToken)
        {
            return _mapper.Map<CutDTO>(await _unitOfWork.CutRepository.GetByIdAsync(id: id, cancellationToken: cancellationToken));
        }
    }
}
