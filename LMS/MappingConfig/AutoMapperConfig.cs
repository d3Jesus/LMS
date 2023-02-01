using LMS.Application.Profiles;

namespace LMS.API.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AuthorProfile));
        }
    }
}
