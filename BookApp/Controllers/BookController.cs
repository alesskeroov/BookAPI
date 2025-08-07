using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;
using BookApp.Repostories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApp.Controllers
{
    public class BookController : Controller
    {
        readonly IBookService _bookService;
        readonly IGenreService _genreService;
        readonly IAuthorService _authorService;
        readonly IPublisherService _publisherService;
        public BookController(IBookService bookService, IGenreService genreService, IAuthorService authorService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
            _publisherService = publisherService;
        }
        public IActionResult Add()
        {
            var model=new Book();
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString() }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString() }).ToList();
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _bookService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Succesfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Erorr has occured on server side";
            return View(model);
        }
        public IActionResult FindById(int id)
        {
            var model = _bookService.FindById(id);
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }

        public IActionResult Update(Book model)
        {
            model.AuthorList = _authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = _publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _bookService.Update(model);
            if (result)
            {
                TempData["msg"] = "Update Succesfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Erorr has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = _bookService.GetAll();
            return View(data);
        }
    }
}
