using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.PublishingCompany
{
    public class AddPublishingCompanyViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
