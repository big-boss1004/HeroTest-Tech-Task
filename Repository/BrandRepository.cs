using HeroTest.Contracts;
using HeroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly SampleContext _context;

        public BrandRepository(SampleContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Set<Brand>().ToListAsync();
        }
    }
}
