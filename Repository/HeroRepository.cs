using HeroTest.Contracts;
using HeroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly SampleContext _context;

        public HeroRepository(SampleContext context)
        {
            _context = context;
        }

        public async Task<Hero> AddHeroAsync(Hero hero)
        {
            await _context.AddAsync(hero);
            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task<List<Hero>> GetAllAsync()
        {
            return await _context.Set<Hero>()
                .Where(x => x.IsActive.HasValue && x.IsActive.Value)
                .Include(a => a.Brand)
                .ToListAsync();
        }

        public async Task<Hero> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<Hero>().FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var hero = await GetAsync(id);
            hero.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
