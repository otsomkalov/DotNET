using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IStoreService
    {
        Task<Store[]> Get(params string[] includes);
        Task<Store> Get(Expression<Func<Store, bool>> expression, params string[] includes);
        Task Create(Store entity);
        Task Update(Store entity);
        Task Remove(Store entity);
    }
}