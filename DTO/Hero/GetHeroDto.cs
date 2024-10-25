namespace HeroTest.DTO.Hero
{
    public class GetHeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Alias { get; set; }
        public bool? IsActive { get; set; }
        public string BrandName { get; set; } = null!;

    }
}
