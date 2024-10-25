using HeroTest.Models;

namespace HeroTest.Contracts
{
    public interface IHeroRepository
    {
        Task<Hero> GetAsync(int? id);
        Task<List<Hero>> GetAllAsync();
        Task<Hero> AddHeroAsync(Hero hero);
        Task DeleteAsync(int id);
    }
}
