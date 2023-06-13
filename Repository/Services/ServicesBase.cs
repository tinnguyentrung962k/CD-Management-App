using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class ServicesBase<T> where T : class
    {
        CDStoreContext _context;
        DbSet<T> _dbSet;

        public ServicesBase()
        {
            _context = new CDStoreContext();
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;

        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public bool Remove(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();

        }

    }
}
