﻿using AutoparkWeb.Models.Entity;
using AutoparkWeb.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Controllers
{
    public class SparePartsController : Controller
    {
        private readonly SparePartsRepository repo;

        public SparePartsController(IRepository<SpareParts> r)
        {
            repo = (SparePartsRepository)r;
        }

        public IActionResult ViewSpareParts()
        {
            return View(repo.GetList());
        }

        public IActionResult CreateSparePart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSparePart(SpareParts detail)
        {
            if (ModelState.IsValid)
            {
                repo.Create(detail);
                return RedirectToAction("ViewSpareParts");
            }
            return View("CreateSparePart");
        }

        public IActionResult EditSparePart(int id)
        {
            SpareParts detail = repo.Get(id);
            return View(detail) ?? (IActionResult)NotFound();
        }

        [HttpPost]
        public IActionResult EditSparePart(SpareParts detail)
        {
            if (ModelState.IsValid)
            {
                repo.Update(detail);
                return RedirectToAction("ViewSpareParts");
            }
            return View("EditSparePart");
        }

        [HttpGet]
        [ActionName("DeleteSparePart")]
        public IActionResult ConfirmSparePartDelete(int id)
        {
            SpareParts detail = repo.Get(id);
            return View(detail) ?? (IActionResult)NotFound();
        }

        [HttpPost]
        public IActionResult DeleteSparePart(int id)
        {
            repo.Delete(id);
            return RedirectToAction("ViewSpareParts");
        }
    }
}
