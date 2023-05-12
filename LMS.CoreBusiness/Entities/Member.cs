using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Entities
{
    public class Member : Person
    {
        private string _docNumber;
        private string _phoneNumber;

        [Required]
        public string DocNumber 
        {
            get { return _docNumber; }
            set { _docNumber = value; } 
        }

        [Required]
        [StringLength(50, ErrorMessage = "This field can have only {0} characters long.")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
    }
}
