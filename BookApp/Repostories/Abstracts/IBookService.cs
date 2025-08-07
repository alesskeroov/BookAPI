using BookApp.Models.Domain;

namespace BookApp.Repostories.Abstracts
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        bool Delete(int id);
        Book FindById(int id);
        IEnumerable<Book> GetAll();
    }
}
