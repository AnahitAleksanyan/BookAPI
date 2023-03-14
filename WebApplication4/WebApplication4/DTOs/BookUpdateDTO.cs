using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }

        public Book ToBook()
        {
            Book book = new Book()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                PageCount = this.PageCount
            };
            return book;
        }

    }
}
