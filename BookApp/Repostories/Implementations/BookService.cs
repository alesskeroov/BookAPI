using BookApp.Models.Context;
using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;

namespace BookApp.Repostories.Implementations
{
    public class BookService:IBookService
    {
        readonly BookAppContext _db;
        public BookService(BookAppContext bookAppContext)
        {
            _db = bookAppContext;
        }
        public bool Add(Book model)
        {
            try
            {
                _db.Books.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = FindById(id);
                if (data == null)
                {
                    return false;
                }
                _db.Books.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Book FindById(int id)
        {
            return _db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _db.Books
                        join author in _db.Authors
                        on book.AuthorId equals author.Id
                        join publisher in _db.Publishers on book.PublisherId equals publisher.Id
                        join genre in _db.Genres on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.GenreId,
                            Isbn = book.Isbn,
                            PublisherId = book.PublisherId,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName
                        }
                       ).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                _db.Books.Update(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
