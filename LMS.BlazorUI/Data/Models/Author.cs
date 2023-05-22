using System.ComponentModel.DataAnnotations;

namespace LMS.BlazorUI.Data.Models
{
    public class Author : Person
    {
        private string _nationality;

        [Required]
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
    }
}
