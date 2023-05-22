namespace LMS.Application.ViewModels.Author
{
    public record GetAuthorDto (int id, string firstName, string lastName, bool wasDeleted, string nationality);
}
