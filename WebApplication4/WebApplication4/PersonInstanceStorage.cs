using WebApplication4.Repositories;

namespace WebApplication4
{
    public class PersonInstanceStorage
    {
        public static readonly PersonListRepository personListRepository = new PersonListRepository();
    }
}
