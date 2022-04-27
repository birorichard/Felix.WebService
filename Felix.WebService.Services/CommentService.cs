using AutoMapper;
using Felix.WebService.Common.Exceptions.Auth;
using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Comment;
using Felix.WebService.Data.Models.Movie;
using Felix.WebService.DTO.Comment;
using Felix.WebService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services
{
    public class CommentService : ICommentService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CommentDTO>> GetComments(int cutId, CancellationToken cancellationToken = default)
        {
            List<string> shotNames = (await _unitOfWork.CommentRepository.GetAsync(
                filter: x => x.ShotCutRel.CutId == cutId && !x.IsDeleted,
                include: x => x.Include(y => y.ShotCutRel).ThenInclude(y => y.Shot),
                cancellationToken: cancellationToken)
                ).Select(x => x.ShotCutRel.Shot.Name)
                .Distinct() 
                .ToList();

            return _mapper.Map<List<CommentDTO>>(await _unitOfWork.CommentRepository.GetAsync(
                filter: x => shotNames.Any(y => y == x.ShotCutRel.Shot.Name) && !x.IsDeleted,
                include: x => x.Include(y => y.CreatedBy),
                cancellationToken: cancellationToken
                ));
        }

        public async Task UpdateComment(CommentDTO dto, CancellationToken cancellationToken = default)
        {
            Comment comment = await _unitOfWork.CommentRepository.GetByIdAsync(id: dto.Id, cancellationToken: cancellationToken);
            _mapper.Map(dto, comment);
            await _unitOfWork.SaveAsync(cancellationToken);
        }

        public async Task CreateCommentFromCommentDTO(CommentDTO dto, CancellationToken cancellationToken = default)
        {
            _unitOfWork.CommentRepository.Create(_mapper.Map(dto, new Comment()));
            
            await _unitOfWork.SaveAsync(cancellationToken);
        }

        public async Task Delete(int userId, int commentId, CancellationToken cancellationToken = default)
        {
            Comment comment = await _unitOfWork.CommentRepository.GetByIdAsync(id: commentId, cancellationToken: cancellationToken);

            if (userId == comment.CreatedBy.Id)
                comment.IsDeleted = true;
            else
                throw new UnauthorizedToDeleteCommentException();

            await _unitOfWork.SaveAsync(cancellationToken);
        }

        public async Task CreateComment(CreateCommentDTO dto, CancellationToken cancellationToken = default)
        {
            Comment comment = _mapper.Map<Comment>(dto);
            ShotCutRel shotCutRel = await _unitOfWork.ShotCutRelRepository.FirstOrDefaultAsync(x => x.CutId == dto.CutId && x.ShotId == dto.ShotId);
            comment.ShotCutRelId = shotCutRel.Id;

            _unitOfWork.CommentRepository.Create(comment);

            await _unitOfWork.SaveAsync(cancellationToken);

        }
    }
}
