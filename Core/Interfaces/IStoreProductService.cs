using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IStoreProductService
    {
        Task<StoreProduct[]> Get(params string[] includes);
        Task<StoreProduct> Get(Expression<Func<StoreProduct, bool>> expression, params string[] includes);
        Task Create(StoreProduct entity);
        Task Update(StoreProduct entity);
        Task Remove(StoreProduct entity);
    }
}