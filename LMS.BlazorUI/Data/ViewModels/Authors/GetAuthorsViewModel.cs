namespace LMS.BlazorUI.Data.ViewModels.Authors
{
    public class GetAuthorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public virtual string FullName 
        // { 
        //     get { return FullName; } 
        //     set { FullName = string.Concat(this.FirstName, " ", this.LastName); }
        // }
    }
}
