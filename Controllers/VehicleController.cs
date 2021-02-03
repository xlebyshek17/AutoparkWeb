using AutoparkWeb.Models.Entity;
using AutoparkWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleRepository repos;

        public VehicleController(IRepository<Vehicle> r)
        {
            repos = (VehicleRepository)r;
        }

        public IActionResult ViewVehicles()
        {
            return View(repos.GetList());
        }

        public IActionResult CreateVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVehicle(Vehicle vehicle)
        {
            repos.Create(vehicle);
            return RedirectToAction("ViewVehicles");
        }

        public IActionResult GetVehicleInfo(int id)
        {
            Vehicle vehicle = repos.Get(id);
            return View(vehicle) ?? (IActionResult)NotFound();
        }

        public IActionResult EditVehicle(int id)
        {
            Vehicle vehicle = repos.Get(id);
            return View(vehicle) ?? (IActionResult)NotFound();
        }


        [HttpPost]
        public IActionResult EditVehicle(Vehicle vehicle)
        {
            repos.Update(vehicle);
            return RedirectToAction("ViewVehicles");
        }

        [HttpGet]
        [ActionName("DeleteVehicle")]
        public IActionResult ConfirmDelete(int id)
        {
            Vehicle vehicle = repos.Get(id);
            return View(vehicle) ?? (IActionResult)NotFound();
        }

        [HttpPost]
        public IActionResult DeleteVehicle(int id)
        {
            repos.Delete(id);
            return RedirectToAction("ViewVehicles");
        }
    }
}
