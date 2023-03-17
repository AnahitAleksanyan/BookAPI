using System.Collections.Generic;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Repositories.Implemetations
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> books = new List<Book>{
            new Book()
            {
                Id = 1,
                Name = "Harry Potter",
                Description = "Harry Potter is a good book",
                PageCount = 500,
                CreatedDate = new DateTime(2001,02,15)
            },
            new Book()
            {
                Id = 2,
                Name = "Hobbits",
                Description = "Hobbits is a good book",
                PageCount = 400,
                CreatedDate = new DateTime(2010,03,25)
            },
            new Book()
            {
                Id = 3,
                Name = "The lord of the Rigs",
                Description = "The lord of the Rigs is a good book",
                PageCount = 600,
                CreatedDate = new DateTime(1996,05,30)
            }
        };

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book? GetBookById(int id)
        {
            return books.Where(book => book.Id == id).FirstOrDefault();
        }

        public Book CreateBook(BookCreateDTO bookDTO)
        {
            var book = bookDTO.ToBook();
            int max = books[0].Id;
            foreach (var item in books)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }

            book.Id = max + 1;

            books.Add(book);
            return book;
        }

        public Book UpdateBook(BookUpdateDTO bookDTO)
        {
            Book? book = GetBookById(bookDTO.Id);

            if (book != null)
            {
                book.Name = bookDTO.Name;
                book.Description = bookDTO.Description;
                book.PageCount = bookDTO.PageCount;
                return book;
            }
            else
            {
                throw new InvalidIdException();
            }

        }

        public bool DeleteBook(int id)
        {
            Book? book = books.Where(book => book.Id == id).FirstOrDefault();
            if (book != null)
            {
                books.Remove(book);
                return true;
            }

            return false;
        }


        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return books.Where(book => book.AuthorId == authorId);
        }

        public bool DeleteAllBooksByAuthorId(int authorId)
        {
            IEnumerable<Book> books = GetBooksByAuthor(authorId);

            var bk = books.ToList();
            foreach (Book book in bk)
            {
                bk.Remove(book);
                return true;
            }
            return false;
        }

    }
}
