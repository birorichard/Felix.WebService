using Felix.WebService.Common.ConfigurationOptions;
using Felix.WebService.Common.Constants;
using Felix.WebService.DAL.Extensions;
using Felix.WebService.Data;

using Felix.WebService.Services.Extensions;
using Felix.WebService.WS.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Felix.WS
{
    public class Startup
    {
        private const int apiVersion = 1;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            JwtOptions jwtOptions = Configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                };
            });

            services.AddAuthorization(configure => configure.AddPolicy(PolicyConstants.AdminOnly, policy => policy.RequireClaim("IsAdmin", "true")));

            services.AddDbContext<FelixDbContext>(options =>
            {
                options.UseSqlServer(Configuration[ConfigKeyConstants.ConnectionStringConfigKeyName]);
            });

            services.RegisterRepositories();
            services.RegisterServices();
            services.RegisterSeeds();
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddConfigurationOptions(Configuration);

            services.AddSwaggerGen(x => 
                x.SwaggerDoc(
                    $"v{apiVersion}", new OpenApiInfo
                    {
                        Title = "Felix Web Service API",
                        Version = $"v{apiVersion}",
                        Description = string.Empty,
                        Contact = new OpenApiContact
                        {
                            Name = "Felix",
                            Email = string.Empty
                        }
                    }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint($"/swagger/v{apiVersion}/swagger.json", $"Felix Web Service API V{apiVersion}");
                x.RoutePrefix = string.Empty;
            });

            app.UseApiResponseHandler();
            app.UseApiKeyAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }

}
