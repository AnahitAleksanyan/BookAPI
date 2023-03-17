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
        private readonly IBookRepository _bookRepository;
        private readonly IPersonRepository _personRepository;
        public BookService(IBookRepository bookRepository, IPersonRepository personRepository)
        {
            _bookRepository = bookRepository;
            _personRepository = personRepository;

        }
        public Book CreateBook(BookCreateDTO bookDTO)
        {
            if (bookDTO.Name == null || bookDTO.Name.Length < 2)
            {
                throw new CustomValidationException("Book name must has at least 2 character");
            }

            ValidateAuthor(bookDTO.AuthorId);

            return _bookRepository.CreateBook(bookDTO);
        }

        private void ValidateAuthor(int authorId)
        {
            bool exists = _personRepository.Exists(authorId);

            if (!exists)
            {
                throw new CustomValidationException("Author id is invalid. Couldn't find person with specified author id.");
            }
        }

        public bool DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }

        public Book? GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        public Book UpdateBook(BookUpdateDTO bookDTO)
        {

            if (bookDTO.Id < 0)
            {
                throw new InvalidIdException();
            }

            return _bookRepository.UpdateBook(bookDTO);
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            ValidateAuthor(authorId);
            return _bookRepository.GetBooksByAuthor(authorId);
        }

        public bool DeleteAllBooksByAuthorId(int authorId)
        {
            if (authorId <= 0)
            {
                throw new InvalidIdException();
            }
            else
            {
               _bookRepository.DeleteAllBooksByAuthorId(authorId);
            }
            return true;
        }
    }
}
