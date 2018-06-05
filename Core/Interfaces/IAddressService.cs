using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IAddressService
    {
        Task<Address[]> Get(params string[] includes);
        Task<Address> Get(Expression<Func<Address, bool>> expression, params string[] includes);
        Task Create(Address entity);
        Task Update(Address entity);
        Task Remove(Address entity);
    }
}