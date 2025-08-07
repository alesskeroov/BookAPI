using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;
using BookApp.Repostories.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class AuthorController : Controller
    {
        readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _authorService.Add(model);
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
            var record = _authorService.FindById(id);
            return View(record);
        }

        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _authorService.Update(model);
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
            var result = _authorService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = _authorService.GetAll();
            return View(data);
        }
    }
}
