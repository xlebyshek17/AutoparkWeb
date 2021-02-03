using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models.Entity.Engine
{
    public abstract class AbstractEngine
    {
        public string EngineType { get; set; }
        public double EngineTaxCoefficient { get; set; }

        public AbstractEngine(string engineType, double engineTaxCoefficient)
        {
            EngineType = engineType;
            EngineTaxCoefficient = engineTaxCoefficient;
        }

        public abstract double GetMaxKilometers(double fuelTankCapacity);
    }
}
