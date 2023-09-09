using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services;

public class AuthorshipService : IAuthorshipService
{
    private readonly IAuthorshipRepository _repository;

    public AuthorshipService(IAuthorshipRepository repository) => _repository = repository;

    public async Task<ServiceResponse<bool>> CreateOrUpdateAsync(int bookId, List<int> bookAuthors)
    {
        var serviceResponse = new ServiceResponse<bool>();
        try
        {
            serviceResponse.ResponseData = await _repository.CreateOrUpdateAsync(bookId, bookAuthors);
            serviceResponse.Message = $"Authors registered successfully!";
        }
        catch (Exception ex)
        {
            serviceResponse.ResponseData = false;
            serviceResponse.Succeeded = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}
