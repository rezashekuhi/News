using Microsoft.AspNetCore.Mvc;
using NewsAPI.Dtos.City;
using NewsAPI.Entities;
using NewsAPI.Exeptions.City;

namespace NewsAPI.Controlers
{
    [Route("cities")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly NewsContext _context;

        public CityController(NewsContext _)
        {
            _context = _;
        }





        [HttpPost]
        public void Add([FromBody] AddCityDto dto)
        {
            var IsExisted = _context.Cities.Any(_ => _.Name == dto.Name);
            if (IsExisted)
            {
                throw new CityAlredyExistedExeption();
            }

            _context.Cities.Add(new City
            {
                Name = dto.Name.ToLower()
            });
            _context.SaveChanges();
        }




        [HttpGet]
        public List<GetAllCitiesDto> GetAll()
        {
            return

                _context.Cities.Select(_ => new GetAllCitiesDto
                {
                    Id = _.Id,
                    Name = _.Name
                }).ToList();
        }

        [HttpPut("{id}")]
        public void Rename([FromRoute] int id, [FromBody] RenameCityDto dto)
        {
            var city = _context.Cities.FirstOrDefault(_ => _.Id == id);

            if (city is null)
            {
                throw new InvalidCityIdExecution();

            }
            if (city.Name==dto.Name)
            {
                city.Name = dto.Name;
            }
            else if (_context.Cities.Any(_ => _.Name == dto.Name.ToLower()))
            {
                throw new SameCityNameExeption();
            }

            city.Name = dto.Name.ToLower();
            _context.SaveChanges();

        }
    }
}