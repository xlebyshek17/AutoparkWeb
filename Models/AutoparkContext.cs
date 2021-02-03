using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoparkWeb.Models.Repositories;

namespace AutoparkWeb.Models
{
    public class AutoparkContext
    {
        public VehicleTypeRepository Types { get; set; }
        public VehicleRepository Vehicles { get; set; }
        public OrdersRepository Orders { get; set; }
        public OrderItemsRepository OrderItems { get; set; }
        public SparePartsRepository SpareParts { get; set; }

        public AutoparkContext(string connection)
        {
            Types = new VehicleTypeRepository(connection);
            Vehicles = new VehicleRepository(connection);
            Orders = new OrdersRepository(connection);
            OrderItems = new OrderItemsRepository(connection);
            SpareParts = new SparePartsRepository(connection);
        }
    }
}
