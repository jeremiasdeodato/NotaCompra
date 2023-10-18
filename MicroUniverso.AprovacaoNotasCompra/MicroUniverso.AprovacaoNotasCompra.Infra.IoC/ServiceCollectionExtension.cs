using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroUniverso.AprovacaoNotasCompra.Application.AutoMapper;
using MicroUniverso.AprovacaoNotasCompra.Application.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Application.Services;
using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services;
using MicroUniverso.AprovacaoNotasCompra.Domain.Services;
using MicroUniverso.AprovacaoNotasCompra.Infra.Data;
using MicroUniverso.AprovacaoNotasCompra.Infra.Data.Repositories;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterApplication(services);
            RegisterDomainServices(services);
            RegisterRepositories(services);
            RegisterCoreServices(services);

            services.AddScoped<IUnitOfWork<ApplicationContext>, UnitOfWork<ApplicationContext>>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(typeof(Profiles));

            return services;
        }

        public static IServiceCollection ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringMysql = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<ApplicationContext>(options =>
                            options.UseMySql(connectionStringMysql,
            ServerVersion.AutoDetect(connectionStringMysql)));
            return services;
        }

        public static IServiceCollection RegisterCoreServices(IServiceCollection services)
        {
            //Caso precise do Core

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<INotaCompraRepository, NotaCompraRepository>();
            services.AddScoped<IFaixaValorAprovacaoRepository, FaixaValorAprovacaoRepository>();
            services.AddScoped<IHistoricoAprovacaoRepository, HistoricoAprovacaoRepository>();

        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<INotaCompraApplication, NotaCompraApplication>();
        }
        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<INotaCompraService, NotaCompraService>();
            services.AddScoped<IFaixaValorAprovacaoService, FaixaValorAprovacaoService>();
            services.AddScoped<IHistoricoAprovacaoService, HistoricoAprovacaoService>();
        }
    }
}
