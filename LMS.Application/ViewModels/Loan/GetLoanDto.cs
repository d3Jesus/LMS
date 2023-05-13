namespace LMS.Application.ViewModels.Request
{
    public record GetLoanDto (int id, int bookId, int memberId, int numberOfCopies);
}
