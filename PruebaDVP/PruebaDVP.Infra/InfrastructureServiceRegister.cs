using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PruebaDVP.Application.Interfaces.Infrastructure.Identity;
using PruebaDVP.Application.Interfaces.Infrastructure.Repositories;
using PruebaDVP.Application.Models.Identity;
using PruebaDVP.Infra.Identity;
using PruebaDVP.Infra.Persistence.SQLSever.Context;
using PruebaDVP.Infra.Repositories;
using System.Text;

namespace PruebaDVP.Infra
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

            var conecctionSqlServer = config.GetConnectionString("SQLConnection");
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(conecctionSqlServer)
            );

            services.AddTransient<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["JwtSettings:Key"]))
            };

            services.AddSingleton(tokenValidationParams);
            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.SaveToken = true;
                opts.TokenValidationParameters = tokenValidationParams;
            });

            return services;
        }
    } 
}
