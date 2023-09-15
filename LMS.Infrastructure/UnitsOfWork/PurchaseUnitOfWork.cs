using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.UnitsOfWork;
using LMS.Infrastructure.Data;
using LMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace LMS.Infrastructure.UnitsOfWork;

public class PurchaseUnitOfWork : IPurchaseUnitOfWork
{
    private readonly ApplicationDbContext _appContext;

    private IDbContextTransaction _appTransaction;
    public IPurchaseRepository PurchaseRepository { get; }
    public IStockRepository StockRepository { get; }

    public PurchaseUnitOfWork(ApplicationDbContext appContext)
    {
        _appContext = appContext;
        PurchaseRepository = new PurchaseRepository(_appContext);
        StockRepository = new StockRepository(_appContext);
    }

    public void BeginTransaction()
    {
        _appTransaction = _appContext.Database.BeginTransaction();
    }

    public bool CommitTransaction()
    {
        try
        {
            _appContext.SaveChanges();
            _appTransaction.Commit();

            return true;
        }
        catch (Exception ex)
        {
            _appTransaction.Rollback();

            Log.Error(ex, ex.Message);

            return false;
        }
    }

    public void RollbackTransaction()
    {
        _appTransaction.Rollback();
        _appTransaction.Dispose();
    }

    public bool SaveChanges()
    {
        try
        {
            _appContext.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            _appTransaction.Rollback();

            Log.Error(ex, ex.Message);

            return false;
        }
    }

    public void Dispose()
    {
        _appTransaction?.Dispose();
        _appContext.Dispose();
    }
}
