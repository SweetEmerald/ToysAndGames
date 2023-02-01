using ToysAndGames.DTO;

namespace ToysAndGames.API.Infrastructure
{
    public static class BuilderServicesExtensions
    {
        public static void ConfigureMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}
