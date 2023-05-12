namespace LMS.Application.ViewModels.Request
{
    public class GetLoanDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
