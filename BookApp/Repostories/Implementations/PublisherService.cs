using BookApp.Models.Context;
using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;
using System.CodeDom;

namespace BookApp.Repostories.Implementations
{
    public class PublisherService:IPublisherService
    {
        readonly BookAppContext _db;
        public PublisherService(BookAppContext bookAppContext)
        {
            _db = bookAppContext;
        }
        public bool Add(Publisher model)
        {
            try
            {
                _db.Publishers.Add(model);
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
                _db.Publishers.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Publisher FindById(int id)
        {
            return _db.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _db.Publishers.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                _db.Publishers.Update(model);
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