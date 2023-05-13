namespace LMS.Application.ViewModels.Request
{
    public record AddLoanDto(int bookId, int memberId, int numberOfCopies);
}
