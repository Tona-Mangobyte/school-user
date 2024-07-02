using SchoolUser.Application.Interfaces.UnitOfWorks;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolUser.Infrastructure.UnitOfWorks
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly DBContext _dbContext;
        private IDbContextTransaction _transaction;

        public UserUnitOfWork(DBContext dbContext, IDbContextTransaction transaction)
        {
            _dbContext = dbContext;
            _transaction = transaction;
        }

        public async Task BeginTransactionAsync()
        {

            if (_transaction != null)
            {
                _transaction?.Dispose();
            }

            try
            {
                _transaction = await _dbContext.Database.BeginTransactionAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }
    }
}