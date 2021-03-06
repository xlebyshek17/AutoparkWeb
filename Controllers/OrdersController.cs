﻿using AutoparkWeb.Models.Entity;
using AutoparkWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersRepository repo;

        public OrdersController(IRepository<Orders> r)
        {
            repo = (OrdersRepository)r;
        }

        public IActionResult ViewOrders()
        {
            return View(repo.GetList());
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Orders order)
        {
            if (ModelState.IsValid)
            {
                repo.Create(order);
                return RedirectToAction("ViewOrders");
            }

            return View("CreateOrder");
            
        }

        public IActionResult GetOrderInfo(int id)
        {
            return View(repo.Get(id));
        }
    }
}
