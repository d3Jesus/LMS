namespace LMS.Application.ViewModels.Acquisition;

public class AddAcquisitionDto
{
    public int LibrarianId { get; set; }

    public List<AcquisitionItemDto> Items { get; set; }
}
