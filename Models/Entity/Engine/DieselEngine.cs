using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models.Entity.Engine
{
    public class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
