using AutoMapper;
using HeroTest.Contracts;
using HeroTest.DTO.Brand;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandRepository.GetAllAsync();
            return Ok(_mapper.Map<List<GetBrandDto>>(brands));
        }
    }
}
