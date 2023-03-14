namespace WebApplication4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
