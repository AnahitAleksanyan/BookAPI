using WebApplication4.Repositories;

namespace WebApplication4
{
    public class BookInstanceStorage
    {
        public static readonly BookRepository bookRepository = new BookRepository();
    }
}
