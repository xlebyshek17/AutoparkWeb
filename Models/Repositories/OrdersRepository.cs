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
    public class OrdersRepository : DbConnection, IRepository<Orders>
    {
        public OrdersRepository(string connection) : base(connection)
        {
            
        }

        public void Create(Orders order)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Insert into Orders(VehicleId) values(@VehicleId)";

                db.Execute(sqlQuery, order);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Delete from Orders where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Orders Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Orders>($"Select * from Orders where Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<Orders> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Orders>($"Select * from Orders").ToList();
            }
        }

        public void Update(Orders order)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Update Orders set VehicleId = @VehicleId where Id = @Id";
                db.Execute(sqlQuery, order);
            }
        }
    }
}
