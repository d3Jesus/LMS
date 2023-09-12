
namespace LMS.CoreBusiness.Entities;

public class Acquisition
{
    public string Id { get; set; }

    public int LibrarianId { get; set; }
    public virtual Librarian Librarian { get; set; }

    public DateTime DateRegistered { get; init; } = DateTime.Now;

    public string Status { get; set; }

    public virtual ICollection<AcquisitionItems> Items { get; set; }
}
