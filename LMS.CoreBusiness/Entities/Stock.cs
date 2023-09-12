namespace LMS.CoreBusiness.Entities
{
    public class Stock
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        
        public int NumberOfCopies { get; set; }
        
        public decimal SalePrice { get; set; }
    }
}
