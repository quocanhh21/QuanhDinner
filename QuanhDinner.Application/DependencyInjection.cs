using Microsoft.Extensions.DependencyInjection;
using QuanhDinner.Application.Services.Authentication;

namespace QuanhDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
