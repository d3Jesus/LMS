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

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthorshipRepository, AuthorshipRepository>();
            services.AddScoped<IAuthorshipService, AuthorshipService>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<ILibrarianRepository, LibrarianRepository>();
            services.AddScoped<ILibrarianService, LibrarianService>();

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoanService, LoanService>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockService, StockService>();

            return services;
        }
    }
}
