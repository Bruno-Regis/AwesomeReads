using AwesomeReads.Core.Repositories;
using AwesomeReads.Infrastructure.Auth;
using AwesomeReads.Infrastructure.ExternalServices;
using AwesomeReads.Infrastructure.Persistence;
using AwesomeReads.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.Design;
using System.Text;

namespace AwesomeReads.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddData(configuration)
                .AddAuth(configuration)
                .AddRepositories()
                .AddExternalServices();

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AwesomeReadsCs");
            services.AddDbContext<AwesomeReadsDbContext>(o => o.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
                            )
                    };
                });

            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
        private static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBookService, BookService>(client =>
            {
                client.BaseAddress = new Uri("https://viacep.com.br/");
                client.Timeout = TimeSpan.FromSeconds(10);
            });

            return services;
        }
    }
}
