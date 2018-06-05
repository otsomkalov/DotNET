using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Task<Address[]> Get(params string[] includes)
        {
            return _addressRepository.Get(includes);
        }

        public Task<Address> Get(Expression<Func<Address, bool>> expression, params string[] includes)
        {
            return _addressRepository.Get(expression, includes);
        }

        public Task Create(Address entity)
        {
            return _addressRepository.Create(entity);
        }

        public Task Update(Address entity)
        {
            return _addressRepository.Update(entity);
        }

        public Task Remove(Address entity)
        {
            return _addressRepository.Remove(entity);
        }
    }
}