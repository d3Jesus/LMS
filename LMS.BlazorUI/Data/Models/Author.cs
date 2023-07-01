using System.ComponentModel.DataAnnotations;

namespace LMS.BlazorUI.Data.Models
{
    public class Author : Person
    {
        private string _nationality;

        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50, ErrorMessage = "This field only accept {1} characters long.")]
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
    }
}
