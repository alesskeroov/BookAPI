using BookApp.Models.Domain;
using BookApp.Repostories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class PublisherController : Controller
    {
        readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _publisherService.Add(model);
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
            var record = _publisherService.FindById(id);
            return View(record);
        }

        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _publisherService.Update(model);
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
            var result = _publisherService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = _publisherService.GetAll();
            return View(data);
        }
    }
}
