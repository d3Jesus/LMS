using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities
{
    public class Reservation
    {
        private int _id;
        private int _bookId;
        private int _memberId;
        private DateTime _reservationDate;
        private string _reservationStatus;

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
        public DateTime ReservationDate
        {
            get { return this._reservationDate; }
            set { this._reservationDate = value; }
        }
        public string ReservationStatus
        {
            get { return this._reservationStatus; }
            set { this._reservationStatus = value; }
        }
    }
}
