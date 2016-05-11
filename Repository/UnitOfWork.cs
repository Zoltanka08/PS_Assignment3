using System;
using ElectroShopRepository.Interfaces;
using Repository.DatabaseContext;

namespace ElectroShopRepository.GenericUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private OnlineClinicEntities _context;
        private bool disposed = false;

        public OnlineClinicEntities DbContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new OnlineClinicEntities();
                }
                return _context;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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