using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ICompanyService
    {
        Task<Company[]> Get(params string[] includes);
        Task<Company> Get(Expression<Func<Company, bool>> expression, params string[] includes);
        Task Create(Company entity);
        Task Update(Company entity);
        Task Remove(Company entity);
    }
}