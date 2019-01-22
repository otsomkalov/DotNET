using System.Threading.Tasks;
using DKR.Data;
using DKR.Models;
using DKR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DKR.Services
{
    public class StoreProductService : IStoreProductService
    {
        private readonly AppDbContext _context;

        public StoreProductService(AppDbContext context)
        {
            _context = context;
        }

        public Task<StoreProduct[]> ListAsync()
        {
            return _context.StoresProducts.ToArrayAsync();
        }

        public Task<StoreProduct> GetByIdAsync(int id)
        {
            return _context.StoresProducts.FindAsync(id);
        }

        public async Task CreateAsync(StoreProduct storeProduct)
        {
            await _context.AddAsync(storeProduct);
        }

        public async Task UpdateAsync(StoreProduct storeProduct)
        {
            _context.Update(storeProduct);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(StoreProduct storeProduct)
        {
            _context.Remove(storeProduct);
            await _context.SaveChangesAsync();
        }
    }
}