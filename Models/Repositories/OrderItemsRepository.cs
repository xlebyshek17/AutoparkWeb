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
                var sqlQuery = $"Select * from SpareParts s " +
                               $"join OrderItems ord " +
                               $"on ord.DetailId = s.Id " +
                               $"left join Orders o " +
                               $"on ord.OrderId = o.Id " +
                               $"left join Vehicles v " +
                               $"on o.VehicleId = v.Id " +
                               $"where ord.Id = @id";

                return db.Query<SpareParts, OrderItems, Orders, Vehicle, OrderItems>(sqlQuery, (sparePart, orderItem, order, vehicle) => { orderItem.Order = order; orderItem.SparePart = sparePart; order.Vehicle = vehicle; return orderItem; }, new { id }).FirstOrDefault();
            }
        }

        public List<OrderItems> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Select * from Orders o " +
                               $"join OrderItems ord " +
                               $"on ord.OrderId = o.Id " +
                               $"left join SpareParts s " +
                               $"on ord.DetailId = s.Id";
                return db.Query<Orders, OrderItems, SpareParts, OrderItems>(sqlQuery, (order, orderItem, sparePart) => { orderItem.Order = order; orderItem.SparePart = sparePart; return orderItem; }).ToList();
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
