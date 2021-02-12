using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoparkWeb.Models.Entity;

namespace AutoparkWeb.Models.Repositories
{
    public class VehicleRepository : DbConnection, IRepository<Vehicle>
    {
        public VehicleRepository(string connection) : base(connection)
        {

        }

        public void Create(Vehicle vehicle)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Insert into Vehicles(TypeId, ModelName, RegistrationNumber, Weight, ManufactureYear, Mileage, TankVolume, Color, Engine) " +
                               $"values(" +
                               $"@TypeId, " +
                               $"@ModelName, " +
                               $"@RegistrationNumber, " +
                               $"@Weight, " +
                               $"@ManufactureYear, " +
                               $"@Mileage," +
                               $"@TankVolume, " +
                               $"@Color, " +
                               $"@Engine)";

                db.Execute(sqlQuery, vehicle);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Delete from Vehicles where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Vehicle Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlquery = $"Select * from Vehicles v " +
                               $"left join VehicleTypes vt " +
                               $"on v.TypeId = vt.Id " +
                               $"where v.Id = @id";
                return db.Query<Vehicle, VehicleType, Vehicle>(sqlquery, (vehicle, type) => { vehicle.Type = type; return vehicle; }, new { id }).FirstOrDefault();
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Update Vehicles set " +
                               $"TypeId = @TypeId, " +
                               $"ModelName = @ModelName, " +
                               $"RegistrationNumber = @RegistrationNumber, " +
                               $"Weight = @Weight, " +
                               $"ManufactureYear = @ManufactureYear, " +
                               $"Mileage = @Mileage, " +
                               $"TankVolume = @TankVolume, " +
                               $"Color = @Color, " +
                               $"Engine = @Engine " +
                               $"where Id = @Id";
                db.Execute(sqlQuery, vehicle);
            }
        }

        public List<Vehicle> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlquery = $"Select * from Vehicles v " +
                               $"left join VehicleTypes vt " +
                               $"on v.TypeId = vt.Id";
                return db.Query<Vehicle, VehicleType, Vehicle>(sqlquery, (vehicle, type) => { vehicle.Type = type; return vehicle; }).ToList();
            }
        }
    }
}
