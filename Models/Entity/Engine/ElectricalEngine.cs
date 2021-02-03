using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models.Entity.Engine
{
    public class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public override double GetMaxKilometers(double batterySize)
        {
            return batterySize / ElectricityConsumption;
        }
    }
}
