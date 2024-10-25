namespace HeroTest.DTO.Hero
{
    public class AddHeroDto
    {
        public string Name { get; set; } = null!;
        public string? Alias { get; set; }
        public int BrandId { get; set; }
    }
}
