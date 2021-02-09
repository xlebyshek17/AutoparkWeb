﻿using AutoparkWeb.Models.Entity;
using AutoparkWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoparkWeb.Controllers
{
    public class VehicleController : Controller
    {
        private VehicleRepository repos;

        public VehicleController(IRepository<Vehicle> r)
        {
            repos = (VehicleRepository)r;
        }

        public IActionResult ViewVehicles(SortState sortOrder = SortState.DefaultByID)
        {
            ViewData["ModelName"] = sortOrder == SortState.ModelNameAsc ? SortState.ModelNameDesc : SortState.ModelNameAsc;
            ViewData["Mileage"] = sortOrder == SortState.MileageAsc ? SortState.MileageDesc : SortState.MileageAsc;
            ViewData["TypeName"] = sortOrder == SortState.TypeNameAsc ? SortState.TypeNameDesc : SortState.TypeNameAsc;

            switch(sortOrder)
            {
                case SortState.ModelNameAsc:
                    return View(repos.GetList().OrderBy(v => v.ModelName));
                case SortState.ModelNameDesc:
                    return View(repos.GetList().OrderByDescending(v => v.ModelName));
                case SortState.MileageAsc:
                    return View(repos.GetList().OrderBy(v => v.Mileage));
                case SortState.MileageDesc:
                    return View(repos.GetList().OrderByDescending(v => v.Mileage));
                case SortState.TypeNameAsc:
                    return View(repos.GetList().OrderBy(v => v.Type).ThenBy(v => v.GetTypeById(v.Id)));
                case SortState.TypeNameDesc:
                    return View(repos.GetList().OrderByDescending(v => v.Type).ThenBy(v => v.GetTypeById(v.Id)));
                default:
                    return View(repos.GetList().OrderBy(v => v.Id));
            }
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
