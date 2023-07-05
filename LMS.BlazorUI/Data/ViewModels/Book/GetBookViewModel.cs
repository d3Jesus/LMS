using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.ViewModels.Authors;

namespace LMS.BlazorUI.Data.ViewModels.Book
{
    public class GetBookViewModel
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
        public int Edition{ get; set; }
        public string ISBN{ get; set; }
        public int CategoryId { get; set; }
        public Category Category{ get; set; }
        public virtual List<GetAuthorsViewModel> Authors { get; set; }
        public string ImageUrl{ get; set; }
        public DateTime DateCreated{ get; set; }
        public decimal Price { get; set; }
    }
}
