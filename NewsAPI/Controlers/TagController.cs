using Microsoft.AspNetCore.Mvc;
using NewsAPI.Dtos.Tag;
using NewsAPI.Exeptions.Tag;


namespace NewsAPI.Controlers
{
    [Route("tags")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly NewsContext _context;

        public TagController(NewsContext _)
        {
            _context = _;
        }




        [HttpPost]
        public void Add(AddTagDto dto)
        {
            var IsExisted = _context.Tags.Any(_ => _.Name == dto.Name);
            if (IsExisted)
            {
                throw new TagAlredyExistedException();
            }
            _context.Tags.Add(new Entities.Tag
            {
                Name = dto.Name,
            });
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)

        {
            var tag =_context.Tags.FirstOrDefault(_ => _.Id == id);
            if (tag is null)
            {
                throw new InvalidTagIdExeption();
            }

            if (_context.NewsTags.Any(_ => _.TagId == tag.Id))
            {
                throw new TagInUseExeption();
            }
          


            _context.Tags.Remove(tag);
            _context.SaveChanges();


        }


    }
}
