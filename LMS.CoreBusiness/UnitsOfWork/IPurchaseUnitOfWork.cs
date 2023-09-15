using LMS.CoreBusiness.Interfaces;

namespace LMS.CoreBusiness.UnitsOfWork;

public interface IPurchaseUnitOfWork
{
    bool SaveChanges();

    void BeginTransaction();

    bool CommitTransaction();

    void RollbackTransaction();

    IPurchaseRepository PurchaseRepository { get; }
    IStockRepository StockRepository { get; }
}
