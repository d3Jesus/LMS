using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LMS.CoreBusiness.Entities
{
    public class Category
    {
        private int _id;
        private string _name;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CategoryName
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
