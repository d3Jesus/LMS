namespace LMS.Application.ViewModels.Loan
{
    public record GetLoanDto (int loanId, string bookTitle, string memberName, int numberOfCopies, DateTime loanDate, bool wasReturned, DateTime returnDate);
}
