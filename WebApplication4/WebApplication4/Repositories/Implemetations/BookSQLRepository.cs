using Microsoft.EntityFrameworkCore;
using WebApplication4.DTOs;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Repositories.Implemetations

{
    public class BookSQLRepository : IBookRepository
    {
        private readonly SQLDBContext _dbContext;

        public BookSQLRepository(SQLDBContext context)
        {
            _dbContext = context;
        }


        public async Task<Book> CreateBook(BookCreateDTO bookDTO)
        {
            var book = bookDTO.ToBook();

            book.CreatedDate = DateTime.Now;
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteAllBooksByAuthorId(int authorId)
        {
            var books = await GetBooksByAuthor(authorId);
            if (books.Any())
            {
                _dbContext.RemoveRange(books);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBook(int id)
        {
            Book? book = await _dbContext.Books.Where(book => book.Id == id).FirstOrDefaultAsync();
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> Exist(int id)
        {
            return await _dbContext.Books.AnyAsync(book => book.Id == id);
        }

        public async Task<Book?> GetBookById(int id)
        {
            Book? book = await _dbContext.Books.Where(book => book.Id == id).FirstOrDefaultAsync();
            return book;

        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
<<<<<<< HEAD
            var books = await _dbContext.Books.Where(_ => true).Include(b => b.Author).ToListAsync();
=======
            var books = await _dbContext.Books.Include(b => b.Author).ToListAsync();
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
            return books;

        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {

            List<Book> list = await _dbContext.Books.Where(book => book.AuthorId == authorId).ToListAsync();
            return list;
        }


        public async Task<Book> UpdateBook(BookUpdateDTO bookDTO)
        {
            Book? book = await GetBookById(bookDTO.Id);
            if (book != null)
            {
                book.Name = bookDTO.Name;
                book.Description = bookDTO.Description;
                book.PageCount = bookDTO.PageCount;
                await _dbContext.SaveChangesAsync();
                return book;
            }
            else
            {
                return bookDTO.ToBook();
            }
        }
    }
}