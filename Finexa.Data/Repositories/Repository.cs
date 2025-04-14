using Finexa.Data.Db_Context;
using Finexa.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected FinexaDbContext _context { get; set; }
        private DbSet<T> _dbSet { get; set; }

        protected Repository(FinexaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public virtual async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbSet.AddRangeAsync(entities);

        public virtual void Update(T entity)
            => _dbSet.Update(entity);

        public virtual void Remove(T entity)
            => _dbSet.Remove(entity);

        public virtual void RemoveRange(IEnumerable<T> entities)
            => _dbSet.RemoveRange(entities);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
