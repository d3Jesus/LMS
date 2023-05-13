using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Entities
{
    public class Member : Person
    {
        private string _docNumber;
        private string _phoneNumber;

        public string DocNumber 
        {
            get { return _docNumber; }
            set { _docNumber = value; } 
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
    }
}
