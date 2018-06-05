using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class StoreService : IStoreService
    {
        private readonly IRepository<Store> _storeRepository;

        public StoreService(IRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Task<Store[]> Get(params string[] includes)
        {
            return _storeRepository.Get(includes);
        }

        public Task<Store> Get(Expression<Func<Store, bool>> expression, params string[] includes)
        {
            return _storeRepository.Get(expression, includes);
        }

        public Task Create(Store entity)
        {
            return _storeRepository.Create(entity);
        }

        public Task Update(Store entity)
        {
            return _storeRepository.Update(entity);
        }

        public Task Remove(Store entity)
        {
            return _storeRepository.Remove(entity);
        }
    }
}