using LMS.Application.ViewModels.Author;
using LMS.Application.ViewModels.Category;

namespace LMS.Application.ViewModels.Book
{
    public class GetBookDto
    {
        public virtual GetCategoryDto Category { get; set; }
        public virtual List<GetAuthorDto> ListOfAuthors { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Edition { get; set; }

        public string ISBN { get; set; }

        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
