using System.Threading.Tasks;
using DKR.Data;
using DKR.Models;
using DKR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DKR.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Product[]> ListAsync()
        {
            return _context.Products.ToArrayAsync();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _context.Products.FindAsync(id);
        }

        public async Task CreateAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}