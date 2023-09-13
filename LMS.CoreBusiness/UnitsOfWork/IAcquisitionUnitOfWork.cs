using LMS.CoreBusiness.Interfaces;

namespace LMS.CoreBusiness.UnitsOfWork;

public interface IAcquisitionUnitOfWork
{
    bool SaveChanges();

    void BeginTransaction();

    bool CommitTransaction();

    void RollbackTransaction();

    IAcquisitionRepository AcquisitionRepository { get; }
    IStockRepository StockRepository { get; }
}
