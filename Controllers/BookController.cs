using Book;
using Book.Models;
using Book.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Reflection;

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        public BooksController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAll()
        {
            //var allBooksDomain=_dbcontext.Books.ToList();
            //return Ok(allBooksDomain);
            var allBooksDomain = _dbcontext.Books;
            //map domain models to DTO
            var allBooksDTO = allBooksDomain.Select(Book => new BookDTO()
            {
                Id = Book.Id,
                Title = Book.Title,
                Description = Book.Description,
                IsRead = Book.IsRead,
                DateRead = Book.IsRead ? Book.DateRead.Value : null,
                Rate = Book.IsRead ? Book.Rate.Value : null,
                Genre = Book.Genre,
                CoverUrl = Book.CoverUrl,
                PublisherName = Book.Publishers.Name,
                AuthorNames = Book.Books_Author.Select(n => n.Author.FullName).ToList()



            }).ToList();
            return Ok(allBooksDTO);
        }
        /*	[HttpGet("{id}")]
			public async Task<IActionResult> GetBooks(int ID)
			{
				var Books = await _dbcontext.Books.FindAsync(ID);
				if (Books == null)
				{
					return NoContent();
				}
				return Ok(Books);
			}
			[HttpPost("{id}")]
			public async Task<IActionResult> AddBook(Books book)
			{
				if (book == null)
				{
					return BadRequest("Book cannot be null.");
				}
				var resul = await _dbcontext.Books.AddAsync(book);
				await _dbcontext.SaveChangesAsync();
				return CreatedAtAction(nameof(GetBooks), new { id = book.ID }, book);
			}


			[HttpPut("{id}")]
			public async Task<IActionResult> UpdateBook(int ID, Books book)
			{
				if (ID != book.ID)
				{
					return BadRequest("Book ID mismatch");
				}
				var bookInDb = await _dbcontext.Books.FindAsync(ID);
				if (bookInDb == null)
				{
					return NotFound();
				}
				_dbcontext.Entry(bookInDb).CurrentValues.SetValues(book);
				await _dbcontext.SaveChangesAsync();
				return NoContent();
			}
			[HttpDelete("{id}")]
			public async Task<IActionResult> DeleteBook(int ID)
			{
				var book = await _dbcontext.Books.FindAsync(ID);
				if (book == null)
				{
					return NotFound();
				}
				_dbcontext.Books.Remove(book);
				await _dbcontext.SaveChangesAsync();
				return NoContent();
			}*/
        [HttpGet]
        [Route("get-book-by-id/{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            //get book domain model from db
            var bookWithDomain = _dbcontext.Books.Where(n => n.Id == id);
            if (bookWithDomain == null)
            {
                return NotFound();
            }
            //map domain model to DTO
            var bookWithIdDTO = bookWithDomain.Select(Book => new BookDTO()
            {
                Id = Book.Id,
                Title = Book.Title,
                Description = Book.Description,
                IsRead = Book.IsRead,
                DateRead = Book.IsRead ? Book.DateRead.Value : null,
                Rate = Book.IsRead ? Book.Rate.Value : null,
                Genre = Book.Genre,
                CoverUrl = Book.CoverUrl,
                PublisherName = Book.Publishers.Name,
                AuthorNames = Book.Books_Author.Select(n => n.Author.FullName).ToList()
            });
            return Ok(bookWithIdDTO);
        }
        //add book to db
        [HttpPost("AddBook")]
        public IActionResult Addbook([FromBody] AddBookRequestDTO addBookRequestDTO)
        {
            //map DTO to domain model
            var bookDomainModel = new Book()
            {
                Title = addBookRequestDTO.Title,
                Description = addBookRequestDTO.Description,
                IsRead = addBookRequestDTO.isRead,
                DateRead = addBookRequestDTO.DateRead,
                Rate = addBookRequestDTO.Rate,
                Genre = addBookRequestDTO.Genre,
                CoverUrl = addBookRequestDTO.CoverUrl,
                DateAdded = addBookRequestDTO.DateAdded,
                PublisherID = addBookRequestDTO.PublisherID,
            };
            //use domain model to add to create book
            _dbcontext.Books.Add(bookDomainModel);
            _dbcontext.SaveChanges();
            foreach (var id in addBookRequestDTO.AuthorIDs)
            {
                var bookAuthor = new Book_Author()
                {
                    BookId = bookDomainModel.Id,
                    AuthorId = id
                };
                _dbcontext.Book_Authors.Add(bookAuthor);
                _dbcontext.SaveChanges();
            }

            return Ok();
        }

        //update book by id
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById([FromRoute] int id, [FromBody] AddBookRequestDTO BookDTO)
        {
            //get book domain model from db
            var bookDomain = _dbcontext.Books.Where(n => n.Id == id).FirstOrDefault();
            if (bookDomain == null)
            {
                return NotFound();
            }
            //map DTO to domain model
            bookDomain.Title = BookDTO.Title;
            bookDomain.Description = BookDTO.Description;
            bookDomain.IsRead = BookDTO.isRead;
            bookDomain.DateRead = BookDTO.DateRead;
            bookDomain.Rate = BookDTO.Rate;
            bookDomain.Genre = BookDTO.Genre;
            bookDomain.CoverUrl = BookDTO.CoverUrl;
            bookDomain.DateAdded = BookDTO.DateAdded;
            bookDomain.PublisherID = BookDTO.PublisherID;
            _dbcontext.SaveChanges();
            //delete all book authors
            var authorsDomain = _dbcontext.Book_Authors.Where(n => n.BookId == id).ToList();
            if (authorsDomain != null)
            {
                _dbcontext.Book_Authors.RemoveRange(authorsDomain);
                _dbcontext.SaveChanges();
            }

            //add new book authors
            foreach (var authorId in BookDTO.AuthorIDs)
            {
                var bookAuthor = new Book_Author()
                {
                    BookId = bookDomain.Id,
                    AuthorId = authorId
                };
                _dbcontext.Book_Authors.Add(bookAuthor);
                _dbcontext.SaveChanges();
            }
            return Ok(BookDTO);
        }
        //delete book by id
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById([FromRoute] int id)
        {
            //get book domain model from db
            var bookDomain = _dbcontext.Books.Where(n => n.Id == id).FirstOrDefault();
            if (bookDomain != null)
            {
                //delete book
                _dbcontext.Books.Remove(bookDomain);
                _dbcontext.SaveChanges();
            }

            return Ok();
        }
    }
}



