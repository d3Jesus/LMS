namespace LMS.CoreBusiness.Entities
{
    public class VwReservation
    {
        private int _reservationId;
        private string _bookTitle;
        private string _memberName;
        private DateTime _dateCreated;
        private string _reservationStatus;

        public int ReservationId
        {
            get { return _reservationId; }
            set { _reservationId = value; }
        }

        public string BookTitle
        { 
            get { return _bookTitle; } 
            set { _bookTitle = value; }
        }

        public string MemberName
        { 
            get { return _memberName; } 
            set { _memberName = value; } 
        }

        public DateTime DateCreated
        { 
            get { return _dateCreated; } 
            set { _dateCreated = value; } 
        }

        public string ReservationStatus
        {
            get { return _reservationStatus; }
            set { _reservationStatus = value; }
        }
    }
}
