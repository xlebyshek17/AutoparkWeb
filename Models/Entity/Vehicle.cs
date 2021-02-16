using System;
using AutoparkWeb.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoparkWeb.Models.Repositories;
using Microsoft.Extensions.Configuration;
using AutoparkWeb.Models.Entity.Engine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AutoparkWeb.Models.Entity
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Fill in the field Type")]
        [Required]
        public int TypeId { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Invalid weight, enter number > 0")]
        [Required]
        public double Weight { get; set; }

        [Range(1885, 2021, ErrorMessage = "Invalid year, enter year > 1885 and < 2021")]
        [Required]
        public int ManufactureYear { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Invalid mileage, enter number > 0")]
        [Required]
        public double Mileage { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Invalid tank volume, enter number > 0")]
        [Required]
        public double TankVolume { get; set; }

        [Required]
        public string Color { get; set; }

        public EngineNames Engine { get; set; }
        public VehicleType Type { get; set; }

        public double GetCalcTaxPerMonth()
        {
            return (Weight * 0.0013) + (GetEngineByName(Engine).EngineTaxCoefficient * Type.TaxCoefficient * 30) + 5;
        }

        public double GetMileageWithFullTank()
        {
            return GetEngineByName(Engine).GetMaxKilometers(TankVolume);
        }

        private AbstractEngine GetEngineByName(EngineNames name)
        {
            switch (name)
            {
                case EngineNames.Gasoline:
                    return new GasolineEngine(2.1, 8.3);
                case EngineNames.Diesel:
                    return new DieselEngine(3, 15);
                case EngineNames.Electrical:
                    return new ElectricalEngine(40);
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
