using LMS.Application.Profiles;

namespace LMS.API.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddAutoMapper(typeof(CategoryProfile));
            services.AddAutoMapper(typeof(AuthorshipProfile));
            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(LibrarianProfile));
            services.AddAutoMapper(typeof(MemberProfile));
            services.AddAutoMapper(typeof(LoanProfile));
            services.AddAutoMapper(typeof(ReservationProfile));
            services.AddAutoMapper(typeof(StockProfile));
        }
    }
}
