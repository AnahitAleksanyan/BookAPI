using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class BookCreateDTO
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public DateTime CreatedDate { get; set; }

        public Book ToBook()
        {
            Book book = new Book();
            
            book.Name = Name;
            book.Description = Description;
            book.PageCount = PageCount;
            book.CreatedDate = CreatedDate;
            return book;
        }

    }
}
