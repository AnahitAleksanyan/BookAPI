namespace WebApplication4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int AuthorId { get; set; }
        public string? Description { get; set; }
        public int PageCount { get; set; }
        public DateTime CreatedDate { get; set; }
<<<<<<< HEAD
         public Person Author { get; set; }
=======
        public Person Author { get; set; }
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
    }
}
