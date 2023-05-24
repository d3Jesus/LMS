using System.ComponentModel.DataAnnotations;

namespace LMS.BlazorUI.Data.Models
{
    public class Member : Person
    {
        private string _docNumber;
        private string _phoneNumber;

        [Required]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        [Required]
        public string DocNumber
        {
            get { return _docNumber; }
            set { _docNumber = value; }
        }
    }
}
