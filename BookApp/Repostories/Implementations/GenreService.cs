using BookApp.Models.Context;
using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;

namespace BookApp.Repostories.Implementations
{
    public class GenreService : IGenreService
    {
        BookAppContext _db;
        public GenreService(BookAppContext bookAppContext)
        {
            _db = bookAppContext;
        }
        public bool Add(Genre model)
        {
            try
            {
                _db.Genres.Add(model);
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
                var data= FindById(id);
                if (data == null)
                {
                    return false;
                }
                _db.Genres.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Genre FindById(int id)
        {
            return _db.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _db.Genres.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                _db.Genres.Update(model);
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
