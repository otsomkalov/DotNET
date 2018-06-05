using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product[]> Get(params string[] includes)
        {
            return _productRepository.Get(includes);
        }

        public Task<Product> Get(Expression<Func<Product, bool>> expression, params string[] includes)
        {
            return _productRepository.Get(expression, includes);
        }

        public Task Create(Product entity)
        {
            return _productRepository.Create(entity);
        }

        public Task Update(Product entity)
        {
            return _productRepository.Update(entity);
        }

        public Task Remove(Product entity)
        {
            return _productRepository.Remove(entity);
        }
    }
}