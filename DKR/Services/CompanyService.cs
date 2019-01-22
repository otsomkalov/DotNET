using System.Threading.Tasks;
using DKR.Data;
using DKR.Models;
using DKR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DKR.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Company[]> ListAsync(params string[] includes)
        {
            return _context.Companies.ToArrayAsync();
        }

        public Task<Company> GetByIdAsync(int id)
        {
            return _context.Companies.FindAsync(id);
        }

        public async Task CreateAsync(Company company)
        {
            await _context.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Company company)
        {
            _context.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Company company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}