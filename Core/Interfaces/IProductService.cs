using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<Product[]> Get(params string[] includes);
        Task<Product> Get(Expression<Func<Product, bool>> expression, params string[] includes);
        Task Create(Product entity);
        Task Update(Product entity);
        Task Remove(Product entity);
    }
}