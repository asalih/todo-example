using DevAssign.Data.Contracts;
using System;
using System.Threading.Tasks;
using DevAssign.Data.Model;
using DevAssign.Data.Context;
using System.Data.Entity;
using DevAssign.Data.Repositories;

namespace DevAssign.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        //PM: Enable-Migrations –EnableAutomaticMigrations
        //PM: Update-Database
        private readonly DbContext context;

        #region Repositories

        #endregion

        public EFUnitOfWork(DbContext dbContext)
        {
            context = dbContext ?? throw new ArgumentNullException("dbContext can not be null.");
        }
        public IRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);
        }

        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch
            {
                //TODO: ExceptionHandling
                throw;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
