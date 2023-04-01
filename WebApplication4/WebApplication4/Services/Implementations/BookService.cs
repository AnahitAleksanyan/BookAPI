using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookSQLRepository;
        private readonly IPersonRepository _personSQLRepository;

        public BookService(IBookRepository bookSQLRepository, IPersonRepository personSQLRepository)
        {
            _bookSQLRepository = bookSQLRepository;
            _personSQLRepository = personSQLRepository;

        }
        public async Task<Book> CreateBook(BookCreateDTO bookDTO)
        {
            if (bookDTO.Name == null || bookDTO.Name.Length < 2)
            {
                throw new CustomValidationException("Book name must has at least 2 character");
            }

            await ValidateAuthor(bookDTO.AuthorId);

            var result = await _bookSQLRepository.CreateBook(bookDTO);
            return result;


        }

        private async Task<bool> ValidateAuthor(int authorId)
        {
            bool exists = await _personSQLRepository.Exists(authorId);

            if (!exists)
            {
                throw new CustomValidationException("Author id is invalid. Couldn't find person with specified author id.");
            }
            return true;
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookSQLRepository.DeleteBook(id);
        }

        public async Task<Book?> GetBookById(int id)
        {
            var result = await _bookSQLRepository.GetBookById(id);

            if (result == null)
            {
                throw new InvalidIdException();
            }

            return result;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookSQLRepository.GetBooks();
        }


        public async Task<Book> UpdateBook(BookUpdateDTO bookDTO)
        {
            var exists = await _bookSQLRepository.Exist(bookDTO.Id);
            if (!exists)
            {
                throw new CustomValidationException("the book is not exist");
            }

            if (bookDTO.Name == null || bookDTO.Name.Length < 2)
            {
                throw new CustomValidationException("Invalid name");
            }

            if (bookDTO.PageCount < 0)
            {
                throw new CustomValidationException("Invalid PageCount");

            }


            return await _bookSQLRepository.UpdateBook(bookDTO);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {
            await ValidateAuthor(authorId);
            return await _bookSQLRepository.GetBooksByAuthor(authorId);
        }

        public async Task<bool> DeleteAllBooksByAuthorId(int authorId)
        {
            if (authorId <= 0)
            {
                throw new InvalidIdException();
            }
            else
            {
                return await _bookSQLRepository.DeleteAllBooksByAuthorId(authorId);
            }
        }

    }
}
