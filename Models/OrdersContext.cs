using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoparkWeb.Models.Repositories;

namespace AutoparkWeb.Models
{
    public class OrdersContext
    {
        public OrdersRepository Orders { get; set; }
        public OrderItemsRepository OrderItems { get; set; }

        public OrdersContext(string connection)
        {
            Orders = new OrdersRepository(connection);
            OrderItems = new OrderItemsRepository(connection);
        }
    }
}
