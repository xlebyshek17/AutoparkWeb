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
    public class VehicleTypeRepository : DbConnection, IRepository<VehicleType>
    {
        public VehicleTypeRepository(string connection) : base(connection)
        {
        }

        public void Create(VehicleType type)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Insert into VehicleTypes (TypeName, TaxCoefficient) " +
                               $"values (@TypeName, @TaxCoefficient)";
                db.Execute(sqlQuery, type);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Delete from VehicleTypes where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public VehicleType Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<VehicleType>($"Select * from VehicleTypes where Id = @id", new { id }).FirstOrDefault();
            }
        }

        public VehicleType GetByName(string typeName)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<VehicleType>($"Select * from VehicleTypes where TypeName = @id", new { typeName }).FirstOrDefault();
            }
        }

        public List<VehicleType> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<VehicleType>($"Select * from VehicleTypes").ToList();
            }
        }

        public void Update(VehicleType type)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Update VehicleTypes set " +
                               $"TypeName = @TypeName, " +
                               $"TaxCoefficient = @TaxCoefficient " +
                               $"where Id = @Id";
                db.Execute(sqlQuery, type);
            }
        }
    }
}
