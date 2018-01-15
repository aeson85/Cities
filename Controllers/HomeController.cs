using Cities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository) => _repository = repository;

        public ViewResult Index() => View(_repository.Cities);

        public ViewResult Create() => View();

        [HttpPost]
        public RedirectToActionResult Create(City city)
        {
            _repository.AddCity(city);
            return RedirectToAction(nameof(Index));
        }
    }
}