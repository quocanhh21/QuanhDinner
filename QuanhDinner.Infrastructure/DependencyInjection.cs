namespace QuanhDinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));
            services.AddSingleton<IJWTTokenGenerator,JWTTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
