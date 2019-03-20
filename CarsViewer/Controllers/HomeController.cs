using CarsViewer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarsViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;

        public HomeController(ICarRepository CarRepository)
        {
            _carRepository = CarRepository;
        }

        public IActionResult Index()
        {
            return View(_carRepository.GetAllCars());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.AddCar(car);
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        public IActionResult Edit(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.UpdateCar(car);
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        public IActionResult Delete(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
                return NotFound();

            _carRepository.DeleteCar(car);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Graph()
        {            
            return View();
        }

        [HttpGet]
        public JsonResult ColorUsageData()
        {
            Dictionary<string, int> percentList = new Dictionary<string, int>();
            foreach(var item in _carRepository.ColorUsagePercent())            
                percentList.Add(item.Color, item.Percent);            

            return new JsonResult(percentList);            
        }

        [HttpGet]
        public JsonResult CarUsageData()
        {
            Dictionary<string, int> percentList = new Dictionary<string, int>();
            foreach (var item in _carRepository.CarUsage())            
                percentList.Add(item.Car, item.Usage);            

            return new JsonResult(percentList);
        }
    }
}
