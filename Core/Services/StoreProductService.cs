using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class StoreProductService : IStoreProductService
    {
        private readonly IRepository<StoreProduct> _storeProductsRepository;

        public StoreProductService(IRepository<StoreProduct> storeRepository)
        {
            _storeProductsRepository = storeRepository;
        }

        public Task<StoreProduct[]> Get(params string[] includes)
        {
            return _storeProductsRepository.Get(includes);
        }

        public Task<StoreProduct> Get(Expression<Func<StoreProduct, bool>> expression, params string[] includes)
        {
            return _storeProductsRepository.Get(expression, includes);
        }

        public Task Create(StoreProduct entity)
        {
            return _storeProductsRepository.Create(entity);
        }

        public Task Update(StoreProduct entity)
        {
            return _storeProductsRepository.Update(entity);
        }

        public Task Remove(StoreProduct entity)
        {
            return _storeProductsRepository.Remove(entity);
        }
    }
}