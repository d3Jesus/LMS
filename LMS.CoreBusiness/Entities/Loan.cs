using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities
{
    public class Loan
    {
        private int _id;
        private int _bookId;
        private int _memberId;
        private int numberOfCopies;
        private DateTime _loanDate;
        private bool _wasReturned;
        private DateTime _dateReturned;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }

        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        public int NumberOfCopies
        {
            get { return numberOfCopies; }
            set { numberOfCopies = value; }
        }

        public DateTime LoanDate
        {
            get { return _loanDate; }
            set { _loanDate = value; }
        }
        public DateTime DateReturned
        {
            get { return _dateReturned; }
            set { _dateReturned = value; }
        }

        public bool WasReturned
        {
            get { return _wasReturned; }
            set { _wasReturned = value; }
        }
    }
}
