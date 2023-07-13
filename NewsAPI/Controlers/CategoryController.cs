using Microsoft.AspNetCore.Mvc;
using NewsAPI.Dtos.Category;
using NewsAPI.Exeptions.Category;

namespace NewsAPI.Controlers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly NewsContext _context;

        public CategoryController(NewsContext _)
        {
            _context = _;
        }


        [HttpPost]
        public void Add([FromBody] AddCategoryDto dto)
        {

            var IsExisted = _context.Categories.Any(_ => _.Name == dto.Name);
            if (IsExisted)
            {
                throw new CategoryAlredyExistedExeption();
            }


            _context.Categories.Add(new Entities.Category
            {
                Name = dto.Name.ToLower(),
            });

            _context.SaveChanges();
        }


        [HttpGet]
        public List<GetAllCategoriesDto> GetAll()
        {
            return

            _context.Categories.Select(_ => new GetAllCategoriesDto
            {
                Id = _.Id,
                Name = _.Name
            }).ToList();

        }






    }
}
