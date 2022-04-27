using Felix.WebService.DAL.Repositories.Interfaces;
using Felix.WebService.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.DAL
{
    public class UnitOfWork
    {
        private readonly FelixDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        private IUserRepository _userRepository;
        private ISeedRepository _seedRepository;
        private IMovieRepository _movieRepository;
        private ICutRepository _cutRepository;
        private IShotCutRelRepository _shotCutRelRepository;
        private IShotRepository _shotRepository;
        private ICommentRepository _commentRepository;

        public UnitOfWork(FelixDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = (IUserRepository)_serviceProvider.GetRequiredService(typeof(IUserRepository));
                }
                return _userRepository;
            }
        }

        public ISeedRepository SeedRepository
        {
            get
            {
                if (_seedRepository == null)
                {
                    _seedRepository = (ISeedRepository)_serviceProvider.GetRequiredService(typeof(ISeedRepository));
                }
                return _seedRepository;
            }
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                if (_movieRepository == null)
                {
                    _movieRepository = (IMovieRepository)_serviceProvider.GetRequiredService(typeof(IMovieRepository));
                }
                return _movieRepository;
            }
        }

        public ICutRepository CutRepository
        {
            get
            {
                if (_cutRepository == null)
                {
                    _cutRepository = (ICutRepository)_serviceProvider.GetRequiredService(typeof(ICutRepository));
                }
                return _cutRepository;
            }
        }

        public IShotRepository ShotRepository
        {
            get
            {
                if (_shotRepository == null)
                {
                    _shotRepository = (IShotRepository)_serviceProvider.GetRequiredService(typeof(IShotRepository));
                }
                return _shotRepository;
            }
        }

        public IShotCutRelRepository ShotCutRelRepository
        {
            get
            {
                if (_shotCutRelRepository == null)
                {
                    _shotCutRelRepository = (IShotCutRelRepository)_serviceProvider.GetRequiredService(typeof(IShotCutRelRepository));
                }
                return _shotCutRelRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = (ICommentRepository)_serviceProvider.GetRequiredService(typeof(ICommentRepository));
                }
                return _commentRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
