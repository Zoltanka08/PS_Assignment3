using ElectroShopRepository.Interfaces;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace ElectroShopRepository.GenericRepository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected OnlineClinicEntities _context;
        private DbSet<T> _dbSet;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.DbContext;
            this._dbSet = unitOfWork.DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }

            return _dbSet.AsEnumerable();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}