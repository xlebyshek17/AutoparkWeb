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
    public class OrderItemsRepository : DbConnection, IRepository<OrderItems>
    {
        public OrderItemsRepository(string connection) : base(connection)
        {
            
        }

        public void Create(OrderItems orderItem)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Insert into OrderItems(OrderId, DetailId, DetailCount) " +
                               $"values(" +
                               $"@OrderId, " +
                               $"@DetailId, " +
                               $"@DetailCount)";
                db.Execute(sqlQuery, orderItem);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Delete from OrderItems where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public OrderItems Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<OrderItems>($"Select * from OrderItems where Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<OrderItems> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<OrderItems>($"Select * from OrderItems").ToList();
            }
        }

        public void Update(OrderItems orderItem)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Update OrderItems set " +
                               $"OrderId = @OrderId, " +
                               $"DetailId = @DetailId, " +
                               $"DetailCount = @DetailCount " +
                               $"where Id = @Id";
                db.Execute(sqlQuery, orderItem);
            }
        }
    }
}
