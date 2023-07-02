namespace LMS.BlazorUI.Data.Models.ViewModels
{
    public class GetBookViewModel
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
        public int Edition{ get; set; }
        public string ISBN{ get; set; }
        public Category Category{ get; set; }
        public string ImageUrl{ get; set; }
        public DateTime DateCreated{ get; set; }
        public decimal Price { get; set; }
    }
}
