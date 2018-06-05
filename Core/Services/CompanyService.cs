using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<Company[]> Get(params string[] includes)
        {
            return _companyRepository.Get(includes);
        }

        public Task<Company> Get(Expression<Func<Company, bool>> expression, params string[] includes)
        {
            return _companyRepository.Get(expression, includes);
        }

        public Task Create(Company entity)
        {
            return _companyRepository.Create(entity);
        }

        public Task Update(Company entity)
        {
            return _companyRepository.Update(entity);
        }

        public Task Remove(Company entity)
        {
            return _companyRepository.Remove(entity);
        }
    }
}