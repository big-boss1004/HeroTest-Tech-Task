using HeroTest.Models;

namespace HeroTest.Contracts
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync();
    }
}
