using FluentValidation.AspNetCore;
using FluentValidation;
using MiniMuhasebecim.UI.Validators.AccountsValidators;

namespace MiniMuhasebecim.UI.Configurations
{
    public static class FluentValidationInjection
    {
        public static IServiceCollection AddFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));

            return services;
        }
    }
}
