namespace LMS.Application.ViewModels.Purchase
{
    public record GetPurchaseDto (int loanId, string bookTitle, string memberName, int numberOfCopies, DateTime loanDate, bool wasReturned, DateTime returnDate);
}
