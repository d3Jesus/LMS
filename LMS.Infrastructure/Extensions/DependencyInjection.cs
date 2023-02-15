using LMS.Application.Interfaces;
using LMS.Application.Services;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using LMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Environment.GetEnvironmentVariable("ConnectionStrings:LmsDefaultConnection")));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IAuthorshipRepository, AuthorshipRepository>();
            services.AddScoped<IAuthorshipService, AuthorshipService>();

            services.AddScoped<IBookcaseRepository, BookcaseRepository>();
            services.AddScoped<IBookcaseService, BookcaseService>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<ILibrarianRepository, LibrarianRepository>();
            services.AddScoped<ILibrarianService, LibrarianService>();

            services.AddScoped<IPublishingCompanyRepository, PublishingCompanyRepository>();
            services.AddScoped<IPublishingCompanyService, PublishingCompanyService>();

            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IReaderService, ReaderService>();

            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestService, RequestService>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockService, StockService>();

            return services;
        }
    }
}
