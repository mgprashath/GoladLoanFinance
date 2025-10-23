using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IDbContextTransaction? _dbContextTransaction;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void BeginTransaction() {
            _dbContextTransaction =  _applicationDbContext.Database.BeginTransaction(); 
        }

        public void CommitTransaction()
        {
            _applicationDbContext.SaveChanges();
            _dbContextTransaction?.Commit();
        }

        public void RollbackTransaction()
        {
            _dbContextTransaction?.Rollback();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContextTransaction?.Dispose();
            _applicationDbContext.Dispose();
        }
    }
}
