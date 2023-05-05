using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDDDPokemonApi.Infrastructure.Entity;
using NetDDDPokemonApi.Infrastructure.Interfaces;
using NetDDDPokemonApi.Infrastructure.Services;

namespace NetDDDPokemonApi.Infrastructure.configuration
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services = services ?? throw new ArgumentNullException (nameof (services));
            configuration = configuration ?? throw new ArgumentNullException (nameof(configuration));

            services.AddDbContext<PokemonDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Pokemon")));
            services.Addservices();

            return services;
        }

        private static IServiceCollection Addservices(this IServiceCollection services)
        {
            services.AddScoped<ITypeDbService, TypeDbService>();
            services.AddScoped<IPokemonDbService, PokemonDbService>();
            services.AddScoped<IUserDbService, UserDbService>();

            return services;
        }
    }
}
