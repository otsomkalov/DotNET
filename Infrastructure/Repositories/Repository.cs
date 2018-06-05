using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public Task<T[]> Get(params string[] includes)
        {
            return _set
                .AsNoTracking()
                .Include(includes)
                .ToArrayAsync();
        }

        public Task<T[]> Get(int count, int offset, params string[] includes)
        {
            return _set
                .AsNoTracking()
                .Include(includes)
                .Skip(offset)
                .Take(count)
                .ToArrayAsync();
        }

        public Task<T[]> Get(Expression<Func<T, bool>> expression, int count, int offset,
            params string[] includes)
        {
            return _set
                .AsNoTracking()
                .Include(includes)
                .Where(expression)
                .Skip(offset)
                .Take(count)
                .ToArrayAsync();
        }

        public Task<T> Get(Expression<Func<T, bool>> expression, params string[] includes)
        {
            return _set
                .AsNoTracking()
                .Include(includes)
                .SingleOrDefaultAsync(expression);
        }

        public Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return _set
                .AsNoTracking()
                .AnyAsync(expression);
        }

        public Task<int> GetCount()
        {
            return _set
                .AsNoTracking()
                .CountAsync();
        }

        public async Task Create(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}