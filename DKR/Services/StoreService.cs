using System.Threading.Tasks;
using DKR.Data;
using DKR.Models;
using DKR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DKR.Services
{
    public class StoreService : IStoreService
    {
        private readonly AppDbContext _context;

        public StoreService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Store[]> ListAsync()
        {
            return _context.Stores.ToArrayAsync();
        }

        public Task<Store> GetByIdAsync(int id)
        {
            return _context.Stores.FindAsync(id);
        }

        public async Task CreateAsync(Store store)
        {
            await _context.AddAsync(store);
        }

        public async Task UpdateAsync(Store store)
        {
            _context.Update(store);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Store store)
        {
            _context.Remove(store);
            await _context.SaveChangesAsync();
        }
    }
}