using AutoparkWeb.Models.Entity;
using AutoparkWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly OrderItemsRepository repo;

        public OrderItemsController(IRepository<OrderItems> r)
        {
            repo = (OrderItemsRepository)r;
        }

        public IActionResult ViewOrderItems(int id)
        {
            return View(repo.Get(id)) ?? (IActionResult)NotFound();
        }

        public IActionResult CreateOrderItems()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrderItems(OrderItems order)
        {
            repo.Create(order);
            return Redirect("~/Orders/ViewOrders");
        }
    }
}
