using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Services;
using Microsoft.Net.Http.Headers;

namespace LMS.BlazorUI.Extentions
{
	public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IBookService, BookService>();
			services.AddScoped<IAuthorService, AuthorService>();

			services.AddHttpClient("local", httpClient =>
			{
				httpClient.BaseAddress = new Uri("https://localhost:7078/api/");

				httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

			});

			return services;
        }
    }
}
