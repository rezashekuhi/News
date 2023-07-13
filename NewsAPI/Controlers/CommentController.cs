using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Dtos.Comment;
using NewsAPI.Exeptions.Comment;
using NewsAPI.Exeptions.News;

namespace NewsAPI.Controlers
{
    [Route("comments")]
    public class CommentController : Controller
    {
        private readonly NewsContext _context;
        public CommentController(NewsContext _)
        {
            _context = _;
        }

        [HttpPost]
        public void Add([FromBody]AddCommentDto dto )
        {
            var isExisted = _context.News.Any(_ => _.Id == dto.NewsId);
            if (!isExisted)
            {
                throw new InvalidNewsIdExecution();
            }

            _context.NewsComments.Add(new Entities.NewsComment
            {
                Date = DateTime.Now,
                IsAprroved = false,
                NewsId = dto.NewsId,
                UserName = dto.UserName,
                Text = dto.Comment

            });
            _context.SaveChanges();

        }

        [HttpPatch("{id}/Approve")]
        public void Approve([FromRoute]int id)
        {
            var comment = _context.NewsComments.FirstOrDefault(_ => _.Id == id);
            if (comment is null)
            {
                throw new IvalidCommentIdExeption();
            }
            if (comment.IsAprroved==true)
            {
                throw new CommentIsAlredyIsAprovedException();
            }

            comment.IsAprroved = true;
            _context.SaveChanges();


        }
     



    }
}
