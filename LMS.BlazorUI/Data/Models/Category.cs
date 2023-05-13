namespace LMS.BlazorUI.Data.Models
{
    public class Category
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CategoryName
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
