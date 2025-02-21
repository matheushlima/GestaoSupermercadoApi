using GestaoSupermercado.Core.Autenticacao;
using GestaoSupermercado.Core.Servicos.Implementacoes;
using GestaoSupermercado.Core.Servicos.Interface;
using GestaoSupermercado.Infraestrutura.Repositorio.Implementacoes;
using GestaoSupermercado.Infraestrutura.Repositorio.Interface;

namespace GestaoSupermercado.API.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServicesCore(this IServiceCollection services)
        {
            services.AddScoped<IProdutoServicos, ProdutoServicos>();
            services.AddScoped<IVendasServicos, VendasServicos>();
            services.AddScoped<IUsuarioServicos, UsuarioServicos>();
            services.AddScoped<JwtServicosAutenticacao>();

            return services;
        }

        public static IServiceCollection AddServicesInfraestrutura(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendasRepository, VendasRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
