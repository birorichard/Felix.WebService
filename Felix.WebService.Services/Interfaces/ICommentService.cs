using Felix.WebService.DTO.Comment;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentDTO>> GetComments(int shotId, CancellationToken cancellationToken);
        Task UpdateComment(CommentDTO dto, CancellationToken cancellationToken);
        Task CreateCommentFromCommentDTO(CommentDTO dto, CancellationToken cancellationToken);
        Task CreateComment(CreateCommentDTO dto, CancellationToken cancellationToken);

        Task Delete(int userId, int commentId, CancellationToken cancellationToken);
    }
}

