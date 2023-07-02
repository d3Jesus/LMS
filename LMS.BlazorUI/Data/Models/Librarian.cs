using System.ComponentModel.DataAnnotations;

namespace LMS.BlazorUI.Data.Models
{
    public class Librarian : Person
    {
        private string _address;
        private string _email;
        private string _phoneNumber;

        [Required(ErrorMessage = "This field is required.")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        [Required(ErrorMessage = "This field is required.")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
