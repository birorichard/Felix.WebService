using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Felix.WebService.Data.Models.Movie;

namespace Felix.WebService.DAL.Repositories
{
    public class MovieRepository : GenericRepository<FelixDbContext, Movie>, IMovieRepository
    {
        public MovieRepository(FelixDbContext dbContext) : base(dbContext)
        {
        }
    }
}
