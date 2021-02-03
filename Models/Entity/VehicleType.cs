using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models.Entity
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        /*public VehicleType()
        {

        }

        public VehicleType(int id, string typeName, double taxCoefficient)
        {
            Id = id;
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public void Display() => Console.WriteLine($"Id = {Id}\nType name = {TypeName}\nTax coefficient = {TaxCoefficient}");

        public override string ToString() => $"{TypeName}, {TaxCoefficient}";*/
    }
}