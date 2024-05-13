using Book.Models.DTO;
using Book.Models.DTO;
namespace Book.Repositories
{
    public interface IBookRepository
    {
        List<BookDTO> GetAllBooks();
        BookDTO GetBookById(int id);
        AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO);
        AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO);
        Book? DeleteBookById(int id);
    }
}
