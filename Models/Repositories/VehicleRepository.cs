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
                var sqlQuery = $"Insert into Vehicles(Type, ModelName, RegistrationNumber, Weight, ManufactureYear, Mileage, TankVolume, Color, Engine) " +
                               $"values(" +
                               $"@Type, " +
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
                return db.Query<Vehicle>($"Select * from Vehicles where Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<Vehicle> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Vehicle>($"Select * from Vehicles").ToList();
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Update Vehicles set " +
                    $"Type = @Type, " +
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

        public List<Vehicle> OrderByModelName()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Vehicle>($"Select * from Vehicles order by ModelName").ToList();
            }
        }

        public List<Vehicle> OrderByMileage()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Vehicle>($"Select * from Vehicles order by Mileage").ToList();
            }
        }

        public List<Vehicle> OrderByType()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Vehicle>($"Select * from Vehicles v " +
                                         $"join VehicleTypes t " +
                                         $"on v.Type = t.Id " +
                                         $"order by t.TypeName").ToList();
            }
        }
    }
}
