using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Felix.WebService.Data.Models.Comment;

namespace Felix.WebService.DAL.Repositories
{
    public class CommentRepository : GenericRepository<FelixDbContext, Comment>, ICommentRepository
    {
        public CommentRepository(FelixDbContext dbContext) : base(dbContext)
        {
        }
    }
}
