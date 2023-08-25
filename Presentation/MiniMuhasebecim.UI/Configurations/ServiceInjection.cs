using MiniMuhasebecim.UI.Services.Abstraction;
using MiniMuhasebecim.UI.Services.Implementation;

namespace MiniMuhasebecim.UI.Configurations
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRestService, RestService>();

            return services;
        }
    }
}
