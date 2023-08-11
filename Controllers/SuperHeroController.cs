using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Ironman",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "US",
                DateAdded = new DateTime(1975, 05, 29),
                DateUpdated = null
            },
            new SuperHero
            {
                Id = 2,
                Name = "Spiderman",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York",
                DateAdded = new DateTime(2001, 06, 29),
                DateUpdated = null
            }
        };

        private readonly IMapper _mapper;

        public SuperHeroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<SuperHero>> GetHeroes()
        {
            return Ok(heroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)));
        }

        [HttpPost]
        public ActionResult<SuperHero> AddHero(SuperHeroDto newHero)
        {
            var hero = _mapper.Map<SuperHero>(newHero);
            heroes.Add(hero);

            return Ok(heroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)));
        } 
    }
}
