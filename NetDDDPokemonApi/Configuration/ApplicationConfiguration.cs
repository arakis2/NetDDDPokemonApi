using NetDDDPokemonApi.Domain.Interfaces;
using NetDDDPokemonApi.Services;

namespace NetDDDPokemonApi.Configuration
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPokemonService, PokemonService>();

            return services;
        }
    }
}
