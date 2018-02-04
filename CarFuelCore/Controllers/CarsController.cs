using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarFuelCore.Models;
using CarFuelCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarFuelCore.Controllers {
  public class CarsController : Controller {

    private readonly IService<Car> _carService;

    public CarsController(IService<Car> carService) {
      _carService = carService;
    }

    [Authorize]
    //[ResponseCache(Duration = 60)]
    public IActionResult Index() {
      //CreateTestCar();

      var cars = _carService.All();
      return View(cars);
    }

    [Authorize]
    public IActionResult Add() {
      return View();
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Car item) {
      if (ModelState.IsValid) {
        try {
          _carService.Add(item);
          _carService.SaveChanges();
          return RedirectToAction("Index");
        }
        catch (Exception ex) {
          ViewBag.Error = ex.Message;
        }
      }
      return View(item);
    }

    private void CreateTestCar() {
      var c = new Car();
      c.Make = "Honda";
      c.Model = "Jazz";
      c.PlateNo = DateTime.Now.Millisecond.ToString();

      c.AddFillUp(1000, 40.0);
      c.AddFillUp(1600, 50.0);
      c.AddFillUp(2200, 60.0);

      _carService.Add(c);
      _carService.SaveChanges();
    }
  }
}