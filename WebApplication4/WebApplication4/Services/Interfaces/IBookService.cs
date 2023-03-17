﻿using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book? GetBookById(int id);
        Book CreateBook(BookCreateDTO bookDTO);
        Book UpdateBook(BookUpdateDTO bookDTO);
        bool DeleteBook(int id);
        IEnumerable<Book> GetBooksByAuthor(int authorId);
        bool DeleteAllBooksByAuthorId(int authorId);
    }
      
}
