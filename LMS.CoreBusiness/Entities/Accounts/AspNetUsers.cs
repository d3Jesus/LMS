
using Microsoft.AspNetCore.Identity;

namespace LMS.CoreBusiness.Entities.Accounts;

public class AspNetUsers : IdentityUser
{
    public int LibrarianId { get; set; }
    public virtual Librarian Librarian { get; set; }
    
    public DateTime DateCreated { get; set; }
}
