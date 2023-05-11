using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
         
        public async Task<IEnumerable<Book>> GetBooks()
        {
           return books;    
        }

        public async Task<Book?> GetBookById(int id)
        {
            var book = books.Where(book => book.Id == id).FirstOrDefault();
            return book;
        }

        public async Task<Book> CreateBook(BookCreateDTO bookDTO)
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

        public async Task<Book> UpdateBook(BookUpdateDTO bookDTO)
        {
            Book? book = await GetBookById(bookDTO.Id);

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

        public async  Task<bool> DeleteBook(int id)
        {
            Book? book =  books.Where(book => book.Id == id).FirstOrDefault();
            if (book != null)
            {
                books.Remove(book); 
                return true;
            }
            return false;
        }


        public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
        {
            return  books.Where(book => book.AuthorId == authorId);
        }

        public async Task<bool> DeleteAllBooksByAuthorId(int authorId)
        {
            IEnumerable<Book> books =await  GetBooksByAuthor(authorId);

            var bk = books.ToList();
            foreach (Book book in bk)
            {
                bk.Remove(book);
                return true;
            }
            return false;
        }

        public async Task<bool> Exist(int id)
        {
            return books.Any(book => book.Id == id);
        }
    }
}
