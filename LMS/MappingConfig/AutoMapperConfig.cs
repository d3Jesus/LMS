using LMS.Application.Profiles;

namespace LMS.API.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddAutoMapper(typeof(AuthorshipProfile));
            services.AddAutoMapper(typeof(BookcaseProfile));
            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(LibrarianProfile));
            services.AddAutoMapper(typeof(PublishingCompanyProfile));
            services.AddAutoMapper(typeof(ReaderProfile));
            services.AddAutoMapper(typeof(RequestProfile));
            services.AddAutoMapper(typeof(ReservationProfile));
            services.AddAutoMapper(typeof(StockProfile));
        }
    }
}
