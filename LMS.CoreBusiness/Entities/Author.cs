using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Entities
{
    public class Author : Person
    {
        private string _nationality;

        [Required]
        [StringLength(30, ErrorMessage = "This field can have only {0} characters long.")]
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
    }
}
