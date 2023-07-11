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
            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(LibrarianProfile));
            services.AddAutoMapper(typeof(PurchaseProfile));
            services.AddAutoMapper(typeof(PurchaseItemsProfile));
            services.AddAutoMapper(typeof(StockProfile));
            services.AddAutoMapper(typeof(AccountProfile));
        }
    }
}
