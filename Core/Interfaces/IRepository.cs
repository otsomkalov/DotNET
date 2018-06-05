using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T[]> Get(params string[] includes);
        Task<T[]> Get(int count, int offset, params string[] includes);
        Task<T[]> Get(Expression<Func<T, bool>> expression, int count, int offset, params string[] includes);
        Task<T> Get(Expression<Func<T, bool>> expression, params string[] includes);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<int> GetCount();
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}