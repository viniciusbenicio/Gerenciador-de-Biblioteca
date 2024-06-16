using GerenciadorLivro.Application.Commands.EmprestimoCQRS.CreateEmprestimo;
using GerenciadorLivro.Application.Commands.LivroCQRS.CreateLivro;
using GerenciadorLivro.Application.Commands.UsuarioCQRS.CreateUsuario;
using GerenciadorLivro.Core.Repositories;
using GerenciadorLivro.Infrastructure.Auth;
using GerenciadorLivro.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GerenciadorLivro.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateLivroCommand)));
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateUsuarioCommand)));
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateEmprestimoCommand)));

            return services;
        }

    }
}
