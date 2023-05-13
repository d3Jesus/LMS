using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Entities
{
    public class Librarian : Person
    {
        private string _address;
        private string _email;
        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Address 
        {
            get { return _address;  }
            set { _address = value; } 
        }
        
        public string Email 
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
