using BookApp.Models.Context;
using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;

namespace BookApp.Repostories.Implementations
{
    public class AuthorSerivice : IAuthorService
    {
        readonly BookAppContext _db;
        public AuthorSerivice(BookAppContext bookAppContext)
        {
            _db = bookAppContext;
        }
        public bool Add(Author model)
        {
            try
            {
                _db.Authors.Add(model);
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
                _db.Authors.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Author FindById(int id)
        {
            return _db.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _db.Authors.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                _db.Authors.Update(model);
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
