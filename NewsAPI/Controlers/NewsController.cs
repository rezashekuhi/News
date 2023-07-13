using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Dtos.News;
using NewsAPI.Dtos.Tag;
using NewsAPI.Entities;
using NewsAPI.Exeptions.City;
using NewsAPI.Exeptions.News;

namespace NewsAPI.Controlers
{
    [Route("news")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly NewsContext _context;

        public NewsController(NewsContext _)
        {
            _context = _;
        }

        [HttpPost]
        public void Add(AddNewsDto dto)
        {
            if (!_context.Cities.Any(_ => _.Id == dto.CityId))
            {
                throw new InvalidCityIdExecution();
            }

            if (!_context.Categories.Any(_ => _.Id == dto.CategoryId))
            {
                throw new CategoryNotFoundException();
            }


            var oldTag = _context.Tags
                .Where(_ => dto.Tags.Any(dtoTag => dtoTag == _.Name)).ToList();
             var oldTagNames = oldTag.Select(t => t.Name).ToList();
             var newTagNames = dto.Tags.Except(oldTagNames);
            
            var newTags = newTagNames.Select(_ => new Tag()
            {
                Name = _
            }).ToList();

            var newsTags1 = oldTag.Select(_ => new NewsTag()
            {
                TagId = _.Id
            }).ToHashSet();
            var newsTags2 = newTags.Select(_ => new NewsTag()
            {
                Tag = _
            }).ToHashSet();

            var allNewsTag = newsTags1.Concat(newsTags2).ToHashSet();


            var news = new News
            {
                CategoryId = dto.CategoryId,
                CityId = dto.CityId,
                Title = dto.Title.ToLower(),
                Text = dto.Text,
                IsSlider = dto.IsSlider,
                Date = DateTime.Now
            };

            news.NewsTags = allNewsTag;

            _context.News.Add(news);
            _context.SaveChanges();
        }

        [HttpPatch("{id}/text-title")]
        public void ChangeTextAndTittle([FromRoute] int id,
            [FromBody] ChangeNewsTextAndTittleDto dto)
        {
            var news = _context.News.FirstOrDefault(_ => _.Id == id);

            if (news is null)
            {
                throw new InvalidNewsIdExecution();
            }

            news.Title = dto.Title.ToLower();
            news.Text = dto.Text;
            _context.SaveChanges();
        }

        [HttpPatch("{id}/change-slider-status")]
        public void ChangeSliderStatus([FromRoute] int id)
        {
            var news = _context.News.FirstOrDefault(_ => _.Id == id);

            if (news is null)
            {
                throw new InvalidNewsIdExecution();
            }

            news.IsSlider = !news.IsSlider;
            _context.SaveChanges();
        }

        [HttpPatch("{id}/change-tags")]
        public void ChangeTags([FromRoute] int id,
            [FromBody] ChangeTagsDto dto)
        {
            var result =
                (from city in _context.Cities
                    join news in _context.News on city.Id equals news.CityId
                    //     into newses
                    // from news in newses.DefaultIfEmpty()
                    select new 
                    {
                        CityId = city.Id,
                        NewsDto = news != null
                            ? new GetANewsDto()
                            {
                                Title = news.Title,
                                Date = news.Date,
                                CityId = news.CityId,
                                CityName = city.Name
                            }
                            : null
                    }).ToList();

            var newResult =
                (from r in result
                    group r by new
                    {
                        CityId = r.CityId
                    }
                    into groups
                    select new
                    {
                        CityId = groups.Key.CityId,
                        Newses = groups
                            .Where(_ => _.NewsDto != null)
                            .ToList()
                    }).ToList();

            // var result = _context.Categories
            //     .Select(_ => new
            //     {
            //         CategoryId = _.Id,
            //         Kharbarats = _.News.ToList()
            //     }).ToQueryString();
            //
            // var n =
            //     (from nnews in _context.News
            //         join city in _context.Cities on nnews.CityId equals city.Id
            //             into cc
            //         from city in cc.DefaultIfEmpty()
            //         group nnews by new
            //         {
            //             city.Id
            //         }
            //         into groupbyy
            //         select new
            //         {
            //             CityId = groupbyy.Key
            //         }).ToList();

            // var r =
            //     (from c in _context.Cities
            //         join contextNew in _context.News on c.Id equals contextNew
            //                 .CityId
            //             into nn
            //         from a in nn.DefaultIfEmpty()
            //         select new
            //         {
            //             CityId = c.Id,
            //             News = a !=null ? new News()
            //             {
            //                 Title = a.Title,
            //                 Id = a.Id
            //             }:null
            //         }).ToList();
            //
            // var rr = (from q in r
            //     group q by new
            //     {
            //         q.CityId
            //     }
            //     into groups
            //     select new
            //     {
            //         CityId = groups.Key.CityId,
            //         Newses = groups.Where(_ => _.News != null).Select(_ =>
            //             new News()
            //             {
            //                 Title = _.News.Title
            //             }).ToList()
            //     }).ToList();

            // var r =
            //     (from c in _context.Cities
            //         join contextNew in _context.News on c.Id equals contextNew
            //                 .CityId
            //             into nn
            //         from a in nn.DefaultIfEmpty()
            //         select new
            //         {
            //             CityId = c.Id,
            //             News = new News()
            //             {
            //                 Title = a.Title,
            //                 Id = a.Id
            //             }
            //         }
            //         into __
            //         group __ by new
            //         {
            //             __.CityId
            //         }
            //         into groupBy
            //         select new
            //         {
            //             CityId = groupBy.Key.CityId,
            //             // Newses = groupBy.Any()?
            //             //     groupBy.Select(_=> new GetANewsDto()
            //             //     {
            //             //        // CityId = _.News.CityId,
            //             //         //Date = _.News.Date,
            //             //        // Title = _.News.Title
            //             //     }).ToList(): new List<GetANewsDto>(),
            //             // IsFolan = groupBy.ToList().Count > 0 ? groupBy.Select(_=>new GetANewsDto()
            //             // {
            //             //     Title = _.News.Title
            //             // }): new List<GetANewsDto>(),
            //             IsFolan = groupBy.ToList().Count
            //         }).ToList();
            //
            //
            // // var r =
            // //     (from c in _context.Cities
            // //         join contextNew in _context.News on c.Id equals contextNew.CityId
            // //             into nn
            // //         from a in nn.DefaultIfEmpty() 
            // //         group a by new
            // //         {
            // //             c.Id,
            // //             c.Name
            // //         } into groupBy
            // //         select new
            // //         {
            // //           CityId = groupBy.Key.Id,
            // //           Newses = groupBy.Select(_=>new News()
            // //           {
            // //               Id = _.Id,
            // //               CityId = _.CityId,
            // //               CategoryId = _.CategoryId,
            // //               Title = _.Title
            // //           }).ToList(),
            // //         }).ToList();

            if (!_context.News.Any(_ => _.Id == id))
            {
                throw new InvalidNewsIdExecution();
            }

            var existedTagCount =
                _context.Tags.Count(_ => dto.NewTagIds.Any(d => d == _.Id));

            if (existedTagCount < dto.NewTagIds.Count())
            {
                throw new Exception("ali exception");
            }

            var existedNewsTagCount = _context.NewsTags.Count(_ =>
                dto.NewTagIds.Any(d => d == _.TagId) &&
                _.NewsId == id);

            if (existedNewsTagCount > 0)
            {
                throw new Exception("existedNewsTagCount");
            }

            var newNewsTags = dto.NewTagIds.Select(_ => new NewsTag()
            {
                NewsId = id,
                TagId = _
            });

            var newsTags = new List<NewsTag>();
            foreach (var item in newNewsTags)
            {
                newsTags.Add(item);
            }


            var oldNewsTags = _context.NewsTags
                .Where(_ => _.NewsId == id &&
                            dto.DeleteTagIds.Any(d => d == _.TagId)).ToList();
            _context.NewsTags.RemoveRange(oldNewsTags);

            _context.NewsTags.AddRange(newsTags);
            _context.SaveChanges();
        }

        [HttpGet]
        public List<GetAllNewsDto> GetAll([FromQuery] SearchOnNewsListDto dto)
        {
            var result = (from news in _context.News
                join city in _context.Cities on news.CityId equals city.Id
                select new GetAllNewsDto
                {
                    CategoryId = news.CategoryId,
                    Title = news.Title,
                    CategoryName = news.Category.Name,
                    CityId = city.Id,
                    CityName = city.Name,
                    Date = news.Date,
                    View = news.View,

                    Tags = news.NewsTags.Select(_ => new NewsTagsDto

                    {
                        Title = _.Tag.Name
                    }).ToList()
                });

            if (dto.Category != null)
            {
                result = result.Where(_ =>
                    _.CategoryName == dto.Category.ToLower());
            }

            if (dto.CityName != null)
            {
                result =
                    result.Where(_ => _.CityName == dto.CityName.ToLower());
            }

            if (dto.Title != null)
            {
                result = result.Where(_ => _.Title == dto.Title.ToLower());
            }

            return result.OrderByDescending(_ => _.Date).ToList();
        }

        [HttpGet("majid")]
        public List<DTO> majid()
        {
            var result = _context.News.Select(n => new DTO
            {
                NewsId = n.Id,
                NewsTitle = n.Title,
                CommentsDto = new CommentsDto
                {
                    AprovedCount = n.NewsComments
                        .Where(_ => _.IsAprroved == true).Count(),
                    DeclinedCount = n.NewsComments
                        .Where(_ => _.IsAprroved == false).Count(),
                    CommentCount = n.NewsComments.Count(),

                    //fixed


                    CommentsUserAndId = new CommentsUserAndId
                    {
                        CommentId = n.NewsComments.Where(_ => _.NewsId == n.Id)
                            .Select(_ => _.Id).FirstOrDefault(),
                        CommentUser = n.NewsComments
                            .Where(_ => _.NewsId == n.Id)
                            .Select(_ => _.UserName).FirstOrDefault()
                    }
                },
                tagsDto = new tagsDto
                {
                    TagCount = n.NewsTags.Count(),
                    TagNames = n.NewsTags.Where(_ => _.NewsId == n.Id)
                        .Select(_ => _.Tag.Name).ToList()
                }
            }).ToList();

            return result;
        }


        [HttpGet("{id}")]
        public GetANewsDto Get([FromRoute] int id)
        {
            var tempNews = _context.News.FirstOrDefault(_ => _.Id == id);
            if (tempNews is null)
            {
                throw new InvalidNewsIdExecution();
            }

            tempNews.View += 1;

            _context.SaveChanges();

            var result = (from news in _context.News
                join city in _context.Cities on news.CityId equals city.Id
                select new GetANewsDto
                {
                    Title = news.Title,
                    Text = news.Text,
                    Date = news.Date,
                    CategoryId = news.CategoryId,
                    CategoryName = news.Category.Name,
                    CityId = city.Id,
                    CityName = city.Name,
                    AprovedComments = news.NewsComments
                        .Where(_ => _.IsAprroved == true)
                        .Select(_ => _.Text).ToList(),

                    Tags = news.NewsTags
                        .Select(_ => _.Tag.Name).ToList(),
                }).First();

            return result;
        }

        [HttpGet("{id}/comments")]
        public List<GetCommentsDto> GetComments([FromRoute] int id,
            [FromQuery] Boolean? aproveState)
        {
            var news = _context.News.Include(_ => _.NewsComments)
                .FirstOrDefault(_ => _.Id == id);

            if (news is null)
            {
                throw new InvalidNewsIdExecution();
            }

            var result = news.NewsComments.Select(_ => new GetCommentsDto
            {
                Comment = _.Text,
                UserName = _.UserName,
                IsAproved = _.IsAprroved
            });

            if (aproveState is true)
            {
                result = result.Where(_ => _.IsAproved == true);
            }

            if (aproveState is false)
            {
                result = result.Where(_ => _.IsAproved == false);
            }

            return result.ToList();
        }

        [HttpGet("sliders")]
        public List<GetSliderNewsDto> GetSliders()
        {
            var result =
                _context.News.Where(_ => _.IsSlider == true)
                    .Select(_ => new GetSliderNewsDto
                    {
                        Date = _.Date,
                        Title = _.Title
                    }).ToList();

            return result;
        }
    }
}