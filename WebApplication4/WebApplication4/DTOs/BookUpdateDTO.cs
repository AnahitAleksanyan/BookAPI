using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }

    }


    public Book ToBook()
    {
        Book book = new Book();
        book.Id = Id;
        book.Name = Name;
        book.Description = Description;
        book.PageCount = PageCount;
        return book;
    }


}
