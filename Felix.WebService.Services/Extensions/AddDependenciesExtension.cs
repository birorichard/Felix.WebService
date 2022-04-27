using Felix.WebService.DAL;
using Felix.WebService.Data;
using Felix.WebService.Services.Interfaces;
using Felix.WebService.Services.Seeds;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Felix.WebService.Services.Extensions
{
    public static class AddDependenciesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UnitOfWork>();
            services.AddScoped<HttpContextAccessor>();
            services.AddScoped<UserContextAccessor>();
            services.AddScoped<ISeedService, SeedService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICutService, CutService>();
            services.AddScoped<IShotService, ShotService>();

            return services;
        }

        public static IServiceCollection RegisterMappers(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterSeeds(this IServiceCollection services)
        {
            services.AddScoped<IDataSeed, AdminDataSeed>();
            services.AddScoped<IDataSeed, ExampleProjectsDataSeed>();
            services.AddScoped<IDataSeed, ExampleCutsDataSeed>();
            services.AddScoped<IDataSeed, ExampleShotsDataSeed>();
            services.AddScoped<IDataSeed, TestUsersDataSeed>();
            services.AddScoped<IDataSeed, ExampleCommentsDataSeed>();

            return services;
        }
    }
}
