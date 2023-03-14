using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book? GetBookById(int id);
        Book CreateBook(BookCreateDTO bookDTO);
        Book UpdateBook(BookUpdateDTO bookDTO);
        bool DeleteBook(int id);
    }
}
