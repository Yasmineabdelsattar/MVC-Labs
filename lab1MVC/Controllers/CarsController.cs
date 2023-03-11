using lab1MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab1MVC.Controllers
{
    //public enum Status
    //{
    //    table,
    //    list
    //}
    
    public class CarsController : Controller
    {
        public IActionResult GetAll()
        {
            var cars = Car.GetCars();
            return View(cars);
        }
        public IActionResult GetDetails(string carModel, string source)
        {
            var car = Car.GetCars().FirstOrDefault(c => c.Model == carModel);
            //Data data = new Data();
            car.Source = source;
            //data.Car = car;
            //return View(data);
            return View( car);
        }

      
        public IActionResult Index()
        {
            return View();
        }
    }
}
