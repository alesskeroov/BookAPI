using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class GenreController : Controller
    {
        readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Add(model);
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
            var record = _genreService.FindById(id);
            return View(record);
        }
   
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Update(model);
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
            var result = _genreService.Delete(id);
            return RedirectToAction("GetAll");
        }
        
        public IActionResult GetAll()
        {
            var data = _genreService.GetAll();
            return View(data);
        }
    }
}
