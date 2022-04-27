using Felix.WebService.DAL.Repositories;
using Felix.WebService.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Felix.WebService.DAL.Extensions
{
    public static class AddDependenciesExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISeedRepository, SeedRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICutRepository, CutRepository>();
            services.AddScoped<IShotCutRelRepository, ShotCutRelRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IShotRepository, ShotRepository>();

            return services;
        }
    }
}
