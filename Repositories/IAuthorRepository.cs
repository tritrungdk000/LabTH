using Book.Repositories;
using Book;
using Microsoft.EntityFrameworkCore;
using Book.Models.DTO;
using WebAPI_simple.Models.DTO;

namespace Book.Repositories
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GellAllAuthors();
        AuthorNoIdDTO GetAuthorById(int id);
        AddAuthorRequestDTO AddAuthor(AddAuthorRequestDTO addAuthorRequestDTO);
        AuthorNoIdDTO UpdateAuthorById(int id, AuthorNoIdDTO authorNoIdDTO);
        Authors? DeleteAuthorById(int id);
    }
}