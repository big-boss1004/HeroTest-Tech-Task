using AutoMapper;
using HeroTest.Contracts;
using HeroTest.DTO.Hero;
using HeroTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHeroRepository _heroRepository;

        public HeroesController(IMapper mapper, IHeroRepository heroRepository)
        {
            _mapper = mapper;
            _heroRepository = heroRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var heroes = await _heroRepository.GetAllAsync();
            return Ok(_mapper.Map<List<GetHeroDto>>(heroes));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([Bind("Name,Alias,BrandId")] AddHeroDto heroDto)
        {
            var hero = _mapper.Map<Hero>(heroDto);
            await _heroRepository.AddHeroAsync(hero);
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hero = await _heroRepository.GetAsync(id);

            if (hero is null)
            {
                return NotFound();
            }

            await _heroRepository.DeleteAsync(id);

            return Ok();
        }
    }
}
