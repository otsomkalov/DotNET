using System.Threading.Tasks;
using DKR.Data;
using DKR.Models;
using DKR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DKR.Services
{
    public class AddressService : IAddressService
    {
        private readonly AppDbContext _context;

        public AddressService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Address[]> ListAsync()
        {
            return _context.Addresses.ToArrayAsync();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            return _context.Addresses.FindAsync(id);
        }

        public async Task CreateAsync(Address address)
        {
            await _context.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Address address)
        {
            _context.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}