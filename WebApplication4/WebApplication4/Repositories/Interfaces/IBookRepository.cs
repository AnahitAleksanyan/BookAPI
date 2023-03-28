using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book?> GetBookById(int id);
        Task<Book> CreateBook(BookCreateDTO bookDTO);
        Task<Book> UpdateBook(BookUpdateDTO bookDTO);
        Task<bool> DeleteBook(int id);
        Task<IEnumerable<Book>> GetBooksByAuthor(int authorId);
        Task<bool> DeleteAllBooksByAuthorId(int authorId);
        Task<bool> Exist(int id);
    }
}
