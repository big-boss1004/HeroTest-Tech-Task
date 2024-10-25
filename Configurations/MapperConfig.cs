using AutoMapper;
using HeroTest.DTO.Brand;
using HeroTest.DTO.Hero;
using HeroTest.Models;

namespace HeroTest.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Hero, GetHeroDto>()
                .ForMember(dest => dest.BrandName, act => act.MapFrom(src => src.Brand.Name));

            CreateMap<Hero, AddHeroDto>().ReverseMap();
            CreateMap<Brand, GetBrandDto>().ReverseMap();
        }
    }
}
