using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Entities
{
    public class Librarian : Person
    {
        private string _address;
        private string _email;
        private string _phoneNumber;

        [Required]
        [StringLength(50, ErrorMessage = "This field can have only {0} characters long.")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        [Required]
        [StringLength(150, ErrorMessage = "This field can have only {0} characters long.")]
        public string Address 
        {
            get { return _address;  }
            set { _address = value; } 
        }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "This field can have only {0} characters long.")]
        public string Email 
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
