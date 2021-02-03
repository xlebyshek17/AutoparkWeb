﻿using System;
using AutoparkWeb.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoparkWeb.Models.Repositories;
using Microsoft.Extensions.Configuration;
using AutoparkWeb.Models.Entity.Engine;

namespace AutoparkWeb.Models.Entity
{
    public class Vehicle //: IComparable<Vehicle>
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public double Weight { get; set; }
        public int ManufactureYear { get; set; }
        public double Mileage { get; set; }
        public double TankVolume { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }

        /*public Vehicle()
        {

        }

        public Vehicle(int id, int type, string modelName, string registrationNumber, double weight,
                int manufactureYear, double mileage, double tankVolume, string color, string engine)
        {
            Id = id;
            Type = type;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            TankVolume = tankVolume;
            Color = color;
            Engine = engine;
        }*/

        public double GetCalcTaxPerMonth()
        {
            return (Weight * 0.0013) + (GetEngineByName(Enum.Parse<EngineNames>(Engine)).EngineTaxCoefficient * GetTypeById(Type).TaxCoefficient * 30) + 5;
        }

        public double GetMileageWithFullTank()
        {
            return GetEngineByName(Enum.Parse<EngineNames>(Engine)).GetMaxKilometers(TankVolume);
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

        public VehicleType GetTypeById(int id)
        {
            string connStr = "Data Source=DESKTOP-I8MCTFK\\SQLEXPRESS;Initial Catalog=AutoPark;Integrated Security=True";
            VehicleTypeRepository type = new VehicleTypeRepository(connStr);
            return type.Get(id);
        }

        /*private int SetTypeByName(string typeName)
        {
            return type.GetByName(typeName).Id;
        }*/

        /*public override string ToString()
        {
            return $"{Id}, {Type}, {ModelName}, {RegistrationNumber}, {Weight}, {ManufactureYear}, " +
                   $"{Mileage}, {TankVolume}, {Color}, {Type.TaxCoefficient}";
        }

        public int CompareTo(Vehicle secondVehicle)
        {
            if (secondVehicle != null)
            {
                return GetCalcTaxPerMonth().CompareTo(secondVehicle.GetCalcTaxPerMonth());
            }
            else
                throw new Exception("It is not possible to compare two objects");
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicle = (Vehicle)obj;

            if (vehicle != null)
            {
                return Type.Equals(vehicle.Type) && ModelName.Equals(vehicle.ModelName);
            }
            else
                throw new Exception("It is not possible to compare two objects");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }*/
    }
}