using Book.Models;
using Book.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        private readonly AppDbContext dbcontext1;
        public PublishersController(AppDbContext dbcontext)
        {
            dbcontext1 = dbcontext;
        }
        //get all publishers
        [HttpGet("get-all-publishers")]
        public IActionResult GetAll()
        {
            var allPublishersDomain = dbcontext1.Publishers;
            //map domain models to DTO
            var allPublishersDTO = allPublishersDomain.Select(Publishers => new PublisherDTO()
            {
                ID = Publishers.Id,
                Name = Publishers.Name,
                Books = Publishers.Book.Select(n => new Book()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description,
                    IsRead = n.IsRead,
                    DateRead = n.DateRead,
                    Rate = n.Rate,
                    Genre = n.Genre,
                    CoverUrl = n.CoverUrl,
                    DateAdded = n.DateAdded,
                    PublisherID = n.PublisherID,

                }).ToList()
            }).ToList();
            return Ok(allPublishersDTO);
        }
        //get publisher by id
        [HttpGet(" get-Publisher-by-Id{id}")]
        public IActionResult GetPublisherId([FromRoute] int id)
        {
            //get publisher domain model from db
            var publisher = dbcontext1.Publishers.FirstOrDefault(n => n.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }
            //map domain model to DTO
            var publisherDTO = new PublisherDTO()
            {
                ID = publisher.Id,
                Name = publisher.Name,
                Books = publisher.Book.Select(n => new Book()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description,
                    IsRead = n.IsRead,
                    DateRead = n.DateRead,
                    Rate = n.Rate,
                    Genre = n.Genre,
                    CoverUrl = n.CoverUrl,
                    DateAdded = n.DateAdded,
                    PublisherID = n.PublisherID,

                }).ToList()
            }; return Ok();
        }

    }
}
