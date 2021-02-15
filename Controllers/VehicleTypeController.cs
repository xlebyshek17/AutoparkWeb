using AutoparkWeb.Models.Entity;
using AutoparkWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly VehicleTypeRepository repo;

        public VehicleTypeController(IRepository<VehicleType> r)
        {
            repo = (VehicleTypeRepository)r;
        }

        public IActionResult ViewVehicleTypes()
        {
            return View(repo.GetList());
        }

        public IActionResult GetTypeInfo(int id)
        {
            VehicleType type = repo.Get(id);
            return View(type) ?? (IActionResult)NotFound();
        }

        public IActionResult CreateType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateType(VehicleType type)
        {
            if (ModelState.IsValid)
            {
                repo.Create(type);
                return RedirectToAction("ViewVehicleTypes");
            }
            return View("CreateType");
        }

        public IActionResult EditType(int id)
        {
            VehicleType type = repo.Get(id);
            return View(type) ?? (IActionResult)NotFound();
        }

        [HttpPost]
        public IActionResult EditType(VehicleType type)
        {
            if (ModelState.IsValid)
            {
                repo.Update(type);
                return RedirectToAction("ViewVehicleTypes");
            }
            return View("EditType");
        }

        [HttpGet]
        [ActionName("DeleteType")]
        public IActionResult ConfirmTypeDelete(int id)
        {
            VehicleType type = repo.Get(id);
            return View(type) ?? (IActionResult)NotFound();
        }

        [HttpPost]
        public IActionResult DeleteType(int id)
        {
            repo.Delete(id);
            return RedirectToAction("ViewVehicleTypes");
        }
    }
}
