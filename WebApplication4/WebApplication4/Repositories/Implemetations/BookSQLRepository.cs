using Microsoft.EntityFrameworkCore;
using WebApplication4.DTOs;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

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
            //ToDo for book asign createdOn as DateTime now

            book.CreatedDate = DateTime.Now;
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteAllBooksByAuthorId(int authorId)
        {
            //ToDo check if books are empty return false

            var books = GetBooksByAuthor(authorId).Result; // stex harc unim
            if (books != null)
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBook(int id)
        {
            //ToDo use FirstOrDefaultAsync 
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
            //ToDo use FirstOrDefaultAsync 
            var book = await _dbContext.Books.Where(book => book.Id == id).FirstOrDefaultAsync();
            await _dbContext.SaveChangesAsync();
            return book;

        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            //ToDo add toListAsync
            var books = await _dbContext.Books.Where(_ => true).ToListAsync();
            //ToDo remove unnessesary SaveChangesAsync
            return books;

        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {
            //ToDo use ToListAsync
            List<Book> list = await _dbContext.Books.Where(book => book.AuthorId == authorId).ToListAsync();

            //ToDo remove unnessesary SaveChangesAsync         

            return list;
        }


        public async Task<Book> UpdateBook(BookUpdateDTO bookDTO)
        {
            Book? book = await GetBookById(bookDTO.Id);
            if (book != null)
            {
                book.Name = bookDTO.Name;
                book.Description = bookDTO.Description;
                await _dbContext.SaveChangesAsync();
                return book;
            }
            else
            {
                //ToDo don't throw exception in repository, just return bookDTO.ToBook()
                return bookDTO.ToBook();
            }
        }
    }
}