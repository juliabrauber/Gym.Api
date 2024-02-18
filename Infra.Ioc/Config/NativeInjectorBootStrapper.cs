using Infra.Storage.EF;
using Microsoft.Extensions.DependencyInjection;
using Business.Abstractions.Interfaces.DapperRepository;
using FluentValidation;
using Infra.Storage.Dapper;
using Infra.Storage.Repositories.Dapper;
using Business.Abstractions.Interfaces.EFRepository;
using Infra.Storage.Repositories.EF;
using MediatR;
using Business.AutoMapper;
using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.User;
using FluentValidation.AspNetCore;
using Business.Services;

namespace Infra.Ioc.Config
{
    public static class NativeInjectorBootstrapper
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IResultOutput<>), typeof(ResultOutput<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserEFRepository, UserEFRepository>();
            services.AddScoped<IUserDapperRepository, UserDapperRepository>();


        }
        public static void RegisterFluentValidationAction(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
        }
        public static void RegisterContexts(this IServiceCollection services)
        {
            services.AddScoped<GymDapperContext>();
            services.AddDbContext<GymEFContext>();

        }
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}